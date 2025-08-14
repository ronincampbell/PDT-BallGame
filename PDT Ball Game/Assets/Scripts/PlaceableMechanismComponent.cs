using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlaceableMechanismComponent : MonoBehaviour
{
   [SerializeField] private Image _image;
   [SerializeField] private AddCoinsChannel _addCoinsChannel;
   [SerializeField] private MatchManagerChannel _matchManagerChannel;

   private RectTransform _canvasRectTransform;
   private InputSystem_Actions _inputs;
   private bool _isPlaceable = false;
   private float _price;
   private Camera _camera;

   public async void Setup(RectTransform canvasRectTransform, float price)
   {
      _canvasRectTransform = canvasRectTransform;
      SetUnplaceable();
      _image.enabled = false;
      await Task.Delay(100);
      _image.enabled = true;
      _price = price;
   }
   
   private void OnEnable()
   {
      _camera = Camera.main;
      _inputs = new InputSystem_Actions();
      _inputs.Enable();
      _inputs.FindAction("Attack").performed += HandleClickPerformed;
      _matchManagerChannel.OnStartRound += HandleStartRound;
   }

   private void HandleStartRound()
   {
      _addCoinsChannel.AddCoins(_price);
      Destroy(gameObject);
   }

   private void OnDisable()
   {
      _matchManagerChannel.OnStartRound -= HandleStartRound;
      _inputs.FindAction("Attack").performed -= HandleClickPerformed;
      _inputs.Disable();
   }

   private void FixedUpdate()
   {
      Vector2 mousePos = _inputs.FindAction("Point").ReadValue<Vector2>();
      Vector2 localPosition;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, mousePos, _camera, out localPosition);
      transform.localPosition = localPosition;
   }
   
   private void HandleClickPerformed(InputAction.CallbackContext context)
   {
      if (!_isPlaceable)
      {
         _addCoinsChannel.AddCoins(_price);
         Destroy(gameObject);
      }
      Destroy(this);
   }

   private void SetUnplaceable()
   {
      _image.color = Color.red;
      _isPlaceable = false;
   }

   private void SetPlaceable()
   {
      _image.color = Color.white;
      _isPlaceable = true;
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      SetPlaceable();
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      SetUnplaceable();
   }

   private void OnCollisionExit2D(Collision2D other)
   {
      SetPlaceable();
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      SetUnplaceable();
   }
}

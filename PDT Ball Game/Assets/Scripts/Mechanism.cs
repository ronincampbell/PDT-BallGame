using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Mechanism : MonoBehaviour
{
   [SerializeField] private Image _image;
   [SerializeField] private AddCoinsChannel _addCoinsChannel;
   
   private RectTransform _canvasRectTransform;
   private InputSystem_Actions _inputs;
   private bool _isPlaceable = false;

   public async void Setup(RectTransform canvasRectTransform)
   {
      _canvasRectTransform = canvasRectTransform;
      SetUnplaceable();
      _image.enabled = false;
      await Task.Delay(100);
      _image.enabled = true;
   }
   
   private void OnEnable()
   {
      _inputs = new InputSystem_Actions();
      _inputs.Enable();
      _inputs.FindAction("Attack").performed += HandleClickPerformed;
   }

   private void OnDisable()
   {
      _inputs.FindAction("Attack").performed -= HandleClickPerformed;
      _inputs.Disable();
   }

   private void FixedUpdate()
   {
      Vector2 mousePos = _inputs.FindAction("Point").ReadValue<Vector2>();
      Vector2 localPosition;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, mousePos, null, out localPosition);

      transform.localPosition = localPosition;
   }
   
   private void HandleClickPerformed(InputAction.CallbackContext context)
   {
      if (!_isPlaceable)
      {
         _addCoinsChannel.AddCoins(100);
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

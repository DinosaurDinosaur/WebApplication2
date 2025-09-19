using Microsoft.AspNetCore.Mvc;

namespace WebApplicationNew.Controllers
{
    // 指定這個 Controller 是 API Controller
    [ApiController]
    // 設定 API 的路由，這裡的 /api/Auth 會對應到網址
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // 定義一個 DTO (Data Transfer Object) 來接收客戶端傳來的資料
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        // 定義一個 POST 方法來處理登入請求
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // 檢查傳入的 model 是否為空或資料不完整
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                // 如果是，回傳 400 Bad Request 狀態碼
                return BadRequest(new { success = false, message = "帳號和密碼不能為空。" });
            }

            // 這裡進行會員帳號與密碼的判斷
            // 理想情況下，應該從資料庫中驗證，這裡為了示範直接硬寫
            if (model.Username == "kk" && model.Password == "kk123")
            {
                // 如果驗證成功，回傳 200 OK 狀態碼
                return Ok(new { success = true, message = "登入成功！" });
            }
            else
            {
                // 如果驗證失敗，回傳 401 Unauthorized 狀態碼
                return Unauthorized(new { success = false, message = "帳號或密碼錯誤。" });
            }
        }
    }
}
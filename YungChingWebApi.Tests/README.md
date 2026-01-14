# YungChingWebApi.Tests

這是 YungChingWebApi 專案的測試專案，使用 xUnit 測試框架。

## 🛠️ 使用的測試工具

- **xUnit**: .NET 測試框架
- **Moq**: Mock 物件框架，用於模擬依賴項
- **FluentAssertions**: 流暢的斷言語法
- **Microsoft.AspNetCore.Mvc.Testing**: 整合測試工具
- **Microsoft.EntityFrameworkCore.InMemory**: 記憶體資料庫，用於測試

## 📁 專案結構

```
YungChingWebApi.Tests/
├── Controllers/           # Controller 測試
│   └── HouseControllerTests.cs
├── Services/             # Service 測試
│   └── HouseServiceTests.cs
├── Helpers/              # 測試輔助工具
│   └── TestDataBuilder.cs
└── README.md
```

## 🚀 執行測試

### 方法 1: 使用 Visual Studio
1. 開啟 **測試總管** (Test > Test Explorer)
2. 點擊 **執行所有測試**

### 方法 2: 使用 .NET CLI
```bash
# 執行所有測試
dotnet test

# 執行測試並顯示詳細資訊
dotnet test --logger "console;verbosity=detailed"

# 執行測試並產生程式碼覆蓋率報告
dotnet test --collect:"XPlat Code Coverage"

# 執行特定測試類別
dotnet test --filter "FullyQualifiedName~HouseControllerTests"

# 執行特定測試方法
dotnet test --filter "Name=GetHouseListByParam_應該回傳房屋列表"
```

## ✍️ 撰寫測試的基本模式

### AAA 模式 (Arrange-Act-Assert)

```csharp
[Fact]
public async Task 測試方法名稱_應該描述預期行為()
{
    // Arrange (準備測試資料和 Mock 物件)
    var mockService = new Mock<IService>();
    mockService.Setup(s => s.GetData()).ReturnsAsync(expectedData);
    var controller = new MyController(mockService.Object);

    // Act (執行要測試的方法)
    var result = await controller.GetData();

    // Assert (驗證結果)
    result.Should().NotBeNull();
    result.Should().BeEquivalentTo(expectedData);
}
```

## 📝 測試命名慣例

使用中文描述性命名，清楚表達測試意圖：
- `方法名稱_測試條件_預期結果`
- 範例：`GetHouseById_當房屋不存在時_應拋出例外`

## 🎯 測試重點

1. **單元測試**: 測試單一元件的功能
   - Controller 測試：驗證 HTTP 回應和路由
   - Service 測試：驗證業務邏輯
   - Repository 測試：驗證資料存取邏輯

2. **Mock 使用**:
   - 使用 Moq 模擬依賴項
   - 避免測試時存取真實資料庫或外部服務

3. **斷言**:
   - 使用 FluentAssertions 提高可讀性
   - 驗證預期結果、錯誤處理和邊界條件

## 📊 程式碼覆蓋率

目標達到至少 80% 的程式碼覆蓋率。

檢查覆蓋率：
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## 🔍 常見測試案例

- ✅ 正常路徑測試
- ✅ 邊界條件測試
- ✅ 空值/null 測試
- ✅ 異常處理測試
- ✅ 驗證 Mock 被正確呼叫

## 📚 參考資源

- [xUnit 官方文件](https://xunit.net/)
- [Moq 快速入門](https://github.com/moq/moq4)
- [FluentAssertions 文件](https://fluentassertions.com/)
- [.NET 測試最佳實踐](https://learn.microsoft.com/zh-tw/dotnet/core/testing/)

## 🤝 貢獻指南

在新增功能時，請確保：
1. 為新的功能撰寫測試
2. 執行所有測試確保沒有破壞現有功能
3. 保持測試程式碼的可讀性和維護性

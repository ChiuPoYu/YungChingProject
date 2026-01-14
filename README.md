# YungChingProject

永慶房屋物件管理系統 API

## 📋 專案說明

此專案為永慶房屋的物件管理系統後端 API，使用 ASP.NET Core 8.0 開發，提供房屋物件與業務人員的資料管理功能。

## 🏗️ 技術架構

- **框架**: .NET 8.0
- **資料庫**: SQL Server
- **ORM**: Entity Framework Core 8.0
- **API 文件**: Swagger/OpenAPI (遵循 RESTful 風格)

## 🚀 初次設定步驟

### 1. Clone 專案
```bash
git clone https://github.com/ChiuPoYu/YungChingProject.git
cd YungChingProject
```

### 2. 安裝相依套件
```bash
cd YungChingWebApi
dotnet restore
```

### 3. 設定資料庫連線字串

建立 `appsettings.Development.json` 中設定您的 SQL Server 連線：

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=YungChing;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

**連線字串參數說明：**
- `Server`: SQL Server 位址和埠號
- `Database`: 資料庫名稱
- `User Id`: SQL Server 登入帳號
- `Password`: SQL Server 登入密碼
- `TrustServerCertificate=True`: 信任本地開發憑證

**或使用 Windows 驗證：**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=YungChing;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### 4. 執行資料庫遷移

```bash
# 建立資料庫並套用 Migration
dotnet ef database update
```

### 5. 執行專案

```bash
dotnet run
```

專案將在 `https://localhost:7xxx` 啟動，可透過 Swagger UI 測試 API。

## 📁 專案結構

```
YungChingWebApi/
├── Controllers/          # API 控制器
├── Data/                 # 資料庫相關
│   ├── SqlDbContext.cs   # EF Core DbContext
│   └── Migrations/       # 資料庫遷移檔案
├── Models/
│   ├── Entities/         # 實體類別(DB模型)
│   │   ├── BaseEntityConfig.cs
│   │   ├── Employee.cs
│   │   └── House.cs
│   ├── Enums/           # 列舉類型
│   │   ├── HouseType.cs
│   │   └── BuildingType.cs
│   ├── Views/           # 視圖模型
│   └── ViewModels/      # ViewModel(資料傳輸物件)
├── Repositories/        # 資料存取層
├── Services/            # 業務邏輯層
└── Program.cs           # 應用程式進入點
```

## 🔄 版本更新記錄

### v1.0.0 - Initial (2026-01-14)

**新增功能：**
- ✅ 建立 Entity 實體類別 (BaseEntityConfig, Employee, House)
- ✅ 建立 Enum 列舉 (HouseType, BuildingType)
- ✅ 建立 SqlDbContext 與資料庫配置
- ✅ 整合 Entity Framework Core 8.0
- ✅ 建立初始資料庫 Migration

**技術更新：**
- 新增 EF Core 相關 NuGet 套件
- 配置 SQL Server 連線
```
---

## 🐛 常見問題

### Q1: 尚未更新Migration
```bash
# 確保使用正確的語法
dotnet ef migrations add MigrationName -c SqlDbContext
```

## 📝 開發規範

- 遵循 C# 命名慣例
- 使用 async/await 處理非同步操作
- 實體類別繼承 `BaseEntityConfig`
- 使用 Repository Pattern 進行資料存取
- 使用 Service Layer 處理業務邏輯

## 👥 開發團隊

- Developer: ChiuPoYu

## 📄 授權

此專案為永慶房屋面試用專案。

---

**最後更新**: 2024-01-14
**分支**: feature/CreateEntities

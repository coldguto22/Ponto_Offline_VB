# Copilot Instructions for Ponto_Offline_VB

## Project Overview
This is a Windows Forms application written in VB.NET for offline management of employee and company data, inspired by Secullum Ponto Offline. The system uses a SQL Server database (default: `DESKTOP-BNHPJH3\SQLEXPRESS`, catalog: `PontoOfflineVB`) and ADODB for data access.

## Architecture & Key Components
- **Forms**: Main UI is organized into forms: `frm_menu` (main menu), `frm_funcionario` (employee management), `frm_empresa` (company management), and their respective registration dialogs (`cad_funcionario`, `cad_empresa`).
- **Data Access**: Centralized in `Module1.vb` with global `db` (ADODB.Connection) and `rs` (ADODB.Recordset) objects. Use `ExecutarConsulta` for SELECTs and `ExecutarComando` for INSERT/UPDATE/DELETE.
- **DataSet**: `PontoOfflineVBDataSet` is used for data binding in forms, but direct SQL is also used for CRUD operations.
- **Photos/Logos**: Employee photos are stored in `bin/Debug/Fotos/`. File operations use `System.IO`.

## Developer Workflows
- **Build**: Use the VS Code task `build` or run `msbuild` in the project root.
- **Run**: Start from `Module1.vb` (`Sub Main`), which initializes the DB connection and opens `frm_menu`.
- **Database**: Ensure SQL Server is running and the `PontoOfflineVB` database exists. Use `Scripts/criar_tb_empresas.sql` to create tables if needed.
- **Debugging**: Most errors are surfaced via `MsgBox` or `MessageBox.Show` dialogs. Connection errors are handled in `Conecta_banco`.

## Project-Specific Patterns
- **Global State**: Shared DB connection and recordset in `Module1.vb`.
- **Form Navigation**: Use `.Show()` for main forms, `.ShowDialog()` for modal dialogs (e.g., registration forms).
- **Data Refresh**: After CRUD operations, call `AtualizarGrid()` to refresh DataGridViews.
- **Validation**: Employee CPF is validated in `cad_funcionario.vb` (`ValidarCPF`).
- **SQL**: SQL is constructed via string concatenation; always sanitize inputs to avoid errors.
- **Photo Handling**: On employee registration, photos are copied to the local `Fotos` directory and referenced by path in the DB.

## Integration Points
- **ADODB**: All DB access is via ADODB. Do not use Entity Framework or ADO.NET DataTables.
- **SQL Server**: Connection string is set in `Module1.vb`. Update `DefaultDataSource` and `DefaultCatalog` as needed.

## Key Files
- `Module1.vb`: DB connection, main entry point, utility functions
- `frm_menu.vb`: Main menu and navigation
- `frm_funcionario.vb`, `cad_funcionario.vb`: Employee management
- `frm_empresa.vb`, `cad_empresa.vb`: Company management
- `PontoOfflineVBDataSet.xsd`: DataSet schema
- `Scripts/criar_tb_empresas.sql`: Table creation script

## Example: Adding a New Employee
1. Open `frm_funcionario` and click "Novo".
2. Fill in the registration form (`cad_funcionario`).
3. On save, the form validates CPF, copies the photo, and inserts/updates the DB.
4. The grid is refreshed via `AtualizarGrid()`.

---

For any new features, follow the patterns in `Module1.vb` for DB access and in the form files for UI logic. Keep all SQL and file operations robust against user input and missing files.

Attribute VB_Name = "Module2"
Public Declare Function OpenProcToken Lib "advapi32.dll" Alias "OpenProcessToken" (ByVal phandle As Long, ByVal daccess As Long, ByRef tokenhandle As Long) As Long
Public Declare Function LookUpPrivValue Lib "advapi32.dll" Alias "LookupPrivilegeValueA" (ByVal sysname As Long, ByRef lookupname As String, ByRef lookupvalue As Long) As Long
Public Declare Function GetCurrProcess Lib "kernel32.dll" Alias "GetCurrentProcess" () As Long


Public Const TOKEN_ASSIGN_PRIMARY = &H1     '
Public Const TOKEN_DUPLICATE = &H2          '
Public Const TOKEN_IMPERSONATE = &H4        '
Public Const TOKEN_QUERY = &H8              '
Public Const TOKEN_QUERY_SOURCE = &H10      '
Public Const TOKEN_ADJUST_PRIVILEGES = &H20 '
Public Const TOKEN_ADJUST_GROUPS = &H40     '
Public Const TOKEN_ADJUST_DEFAULT = &H80    '
Public Const TOKEN_ADJUST_SESSIONID = &H100 '



Public Const SE_CREATE_TOKEN_NAME = "SeCreateTokenPrivilege"
Public Const SE_ASSIGNPRIMARYTOKEN_NAME = "SeAssignPrimaryTokenPrivilege"
Public Const SE_LOCK_MEMORY_NAME = "SeLockMemoryPrivilege"
Public Const SE_INCREASE_QUOTA_NAME = "SeIncreaseQuotaPrivilege"
Public Const SE_UNSOLICITED_INPUT_NAME = "SeUnsolicitedInputPrivilege"
Public Const SE_MACHINE_ACCOUNT_NAME = "SeMachineAccountPrivilege"
Public Const SE_TCB_NAME = "SeTcbPrivilege"
Public Const SE_SECURITY_NAME = "SeSecurityPrivilege"
Public Const SE_TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege"
Public Const SE_LOAD_DRIVER_NAME = "SeLoadDriverPrivilege"
Public Const SE_SYSTEM_PROFILE_NAME = "SeSystemProfilePrivilege"
Public Const SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege"
Public Const SE_PROF_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege"
Public Const SE_INC_BASE_PRIORITY_NAME = "SeIncreaseBasePriorityPrivilege"
Public Const SE_CREATE_PAGEFILE_NAME = "SeCreatePagefilePrivilege"
Public Const SE_CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege"
Public Const SE_BACKUP_NAME = "SeBackupPrivilege"
Public Const SE_RESTORE_NAME = "SeRestorePrivilege"
Public Const SE_SHUTDOWN_NAME = "SeShutdownPrivilege"
Public Const SE_DEBUG_NAME = "SeDebugPrivilege"
Public Const SE_AUDIT_NAME = "SeAuditPrivilege"
Public Const SE_SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege"
Public Const SE_CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege"
Public Const SE_REMOTE_SHUTDOWN_NAME = "SeRemoteShutdownPrivilege"

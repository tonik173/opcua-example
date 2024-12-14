
export enum DataTypeIds {
   DeviceHealthEnumeration = 'i=6244',
   FetchResultDataType = 'i=6522',
   TransferResultErrorDataType = 'i=15888',
   TransferResultDataDataType = 'i=15889',
   ParameterResultDataType = 'i=6525',
   SoftwareVersionFileType = 'i=331',
   UpdateBehavior = 'i=333'
}

export enum MethodIds {
   TopologyElementType_Lock_InitLock = 'i=6166',
   TopologyElementType_Lock_RenewLock = 'i=6169',
   TopologyElementType_Lock_ExitLock = 'i=6171',
   TopologyElementType_Lock_BreakLock = 'i=6173',
   ComponentType_Lock_InitLock = 'i=6166',
   ComponentType_Lock_RenewLock = 'i=6169',
   ComponentType_Lock_ExitLock = 'i=6171',
   ComponentType_Lock_BreakLock = 'i=6173',
   DeviceType_Lock_InitLock = 'i=6166',
   DeviceType_Lock_RenewLock = 'i=6169',
   DeviceType_Lock_ExitLock = 'i=6171',
   DeviceType_Lock_BreakLock = 'i=6173',
   DeviceType_CPIdentifier_Lock_InitLock = 'i=6166',
   DeviceType_CPIdentifier_Lock_RenewLock = 'i=6169',
   DeviceType_CPIdentifier_Lock_ExitLock = 'i=6171',
   DeviceType_CPIdentifier_Lock_BreakLock = 'i=6173',
   SoftwareType_Lock_InitLock = 'i=6166',
   SoftwareType_Lock_RenewLock = 'i=6169',
   SoftwareType_Lock_ExitLock = 'i=6171',
   SoftwareType_Lock_BreakLock = 'i=6173',
   BlockType_Lock_InitLock = 'i=6166',
   BlockType_Lock_RenewLock = 'i=6169',
   BlockType_Lock_ExitLock = 'i=6171',
   BlockType_Lock_BreakLock = 'i=6173',
   NetworkType_CPIdentifier_Lock_InitLock = 'i=6166',
   NetworkType_CPIdentifier_Lock_RenewLock = 'i=6169',
   NetworkType_CPIdentifier_Lock_ExitLock = 'i=6171',
   NetworkType_CPIdentifier_Lock_BreakLock = 'i=6173',
   NetworkType_Lock_InitLock = 'i=6299',
   NetworkType_Lock_RenewLock = 'i=6302',
   NetworkType_Lock_ExitLock = 'i=6304',
   NetworkType_Lock_BreakLock = 'i=6306',
   ConnectionPointType_Lock_InitLock = 'i=6166',
   ConnectionPointType_Lock_RenewLock = 'i=6169',
   ConnectionPointType_Lock_ExitLock = 'i=6171',
   ConnectionPointType_Lock_BreakLock = 'i=6173',
   ConnectionPointType_NetworkIdentifier_Lock_InitLock = 'i=6299',
   ConnectionPointType_NetworkIdentifier_Lock_RenewLock = 'i=6302',
   ConnectionPointType_NetworkIdentifier_Lock_ExitLock = 'i=6304',
   ConnectionPointType_NetworkIdentifier_Lock_BreakLock = 'i=6306',
   TransferServicesType_TransferToDevice = 'i=6527',
   TransferServicesType_TransferFromDevice = 'i=6529',
   TransferServicesType_FetchTransferResultData = 'i=6531',
   LockingServicesType_InitLock = 'i=6393',
   LockingServicesType_RenewLock = 'i=6396',
   LockingServicesType_ExitLock = 'i=6398',
   LockingServicesType_BreakLock = 'i=6400',
   SoftwareUpdateType_PrepareForUpdate_Prepare = 'i=19',
   SoftwareUpdateType_PrepareForUpdate_Abort = 'i=20',
   SoftwareUpdateType_Installation_Resume = 'i=61',
   SoftwareUpdateType_Confirmation_Confirm = 'i=112',
   SoftwareUpdateType_Parameters_GenerateFileForRead = 'i=124',
   SoftwareUpdateType_Parameters_GenerateFileForWrite = 'i=127',
   SoftwareUpdateType_Parameters_CloseAndCommit = 'i=130',
   PackageLoadingType_FileTransfer_GenerateFileForRead = 'i=142',
   PackageLoadingType_FileTransfer_GenerateFileForWrite = 'i=145',
   PackageLoadingType_FileTransfer_CloseAndCommit = 'i=148',
   DirectLoadingType_FileTransfer_GenerateFileForRead = 'i=142',
   DirectLoadingType_FileTransfer_GenerateFileForWrite = 'i=145',
   DirectLoadingType_FileTransfer_CloseAndCommit = 'i=148',
   CachedLoadingType_FileTransfer_GenerateFileForRead = 'i=142',
   CachedLoadingType_FileTransfer_GenerateFileForWrite = 'i=145',
   CachedLoadingType_FileTransfer_CloseAndCommit = 'i=148',
   CachedLoadingType_GetUpdateBehavior = 'i=189',
   FileSystemLoadingType_FileSystem_CreateDirectory = 'i=195',
   FileSystemLoadingType_FileSystem_CreateFile = 'i=198',
   FileSystemLoadingType_FileSystem_DeleteFileSystemObject = 'i=201',
   FileSystemLoadingType_FileSystem_MoveOrCopy = 'i=203',
   FileSystemLoadingType_GetUpdateBehavior = 'i=206',
   FileSystemLoadingType_ValidateFiles = 'i=209',
   PrepareForUpdateStateMachineType_Prepare = 'i=228',
   PrepareForUpdateStateMachineType_Abort = 'i=229',
   PrepareForUpdateStateMachineType_Resume = 'i=230',
   InstallationStateMachineType_InstallSoftwarePackage = 'i=265',
   InstallationStateMachineType_InstallFiles = 'i=268',
   InstallationStateMachineType_Resume = 'i=270',
   ConfirmationStateMachineType_Confirm = 'i=321',
,
,
,
,
,
,
,
,
,
,

}

export enum ObjectIds {
   DeviceSet = 'i=5001',
   DeviceFeatures = 'i=15034',
   NetworkSet = 'i=6078',
   DeviceTopology = 'i=6094'
}

export enum ObjectTypeIds {
   TopologyElementType = 'i=1001',
   IVendorNameplateType = 'i=15035',
   ITagNameplateType = 'i=15048',
   IDeviceHealthType = 'i=15051',
   ISupportInfoType = 'i=15054',
   ComponentType = 'i=15063',
   DeviceType = 'i=1002',
   SoftwareType = 'i=15106',
   BlockType = 'i=1003',
   DeviceHealthDiagnosticAlarmType = 'i=15143',
   FailureAlarmType = 'i=15292',
   CheckFunctionAlarmType = 'i=15441',
   OffSpecAlarmType = 'i=15590',
   MaintenanceRequiredAlarmType = 'i=15739',
   ConfigurableObjectType = 'i=1004',
   FunctionalGroupType = 'i=1005',
   ProtocolType = 'i=1006',
   NetworkType = 'i=6247',
   ConnectionPointType = 'i=6308',
   TransferServicesType = 'i=6526',
   LockingServicesType = 'i=6388',
   SoftwareUpdateType = 'i=1',
   SoftwareLoadingType = 'i=135',
   PackageLoadingType = 'i=137',
   DirectLoadingType = 'i=153',
   CachedLoadingType = 'i=171',
   FileSystemLoadingType = 'i=192',
   SoftwareVersionType = 'i=212',
   PrepareForUpdateStateMachineType = 'i=213',
   InstallationStateMachineType = 'i=249',
   PowerCycleStateMachineType = 'i=285',
   ConfirmationStateMachineType = 'i=307'
}

export enum ReferenceTypeIds {
   ConnectsTo = 'i=6030',
   ConnectsToParent = 'i=6467',
   IsOnline = 'i=6031'
}

export enum VariableTypeIds {
   UIElementType = 'i=6246'
}

export class StatusCode {
   public static isGood(code?: number): boolean {
      return !code || (code & 0xD0000000) === 0;
   }
   public static isUncertain(code?: number): boolean {
      return (code ?? 0 & 0x40000000) !== 0;
   }
   public static isBad(code?: number): boolean {
      return (code ?? 0 & 0x80000000) !== 0;
   }
}


export enum ObjectIds {
   MachineryItemState_StateMachineType_Executing = 'i=5006',
   MachineryItemState_StateMachineType_FromExecutingToExecuting = 'i=5023',
   MachineryItemState_StateMachineType_FromExecutingToNotAvailable = 'i=5020',
   MachineryItemState_StateMachineType_FromExecutingToNotExecuting = 'i=5022',
   MachineryItemState_StateMachineType_FromExecutingToOutOfService = 'i=5021',
   MachineryItemState_StateMachineType_FromNotAvailableToExecuting = 'i=5010',
   MachineryItemState_StateMachineType_FromNotAvailableToNotAvailable = 'i=5011',
   MachineryItemState_StateMachineType_FromNotAvailableToNotExecuting = 'i=5009',
   MachineryItemState_StateMachineType_FromNotAvailableToOutOfService = 'i=5008',
   MachineryItemState_StateMachineType_FromNotExecutingToExecuting = 'i=5018',
   MachineryItemState_StateMachineType_FromNotExecutingToNotAvailable = 'i=5016',
   MachineryItemState_StateMachineType_FromNotExecutingToNotExecuting = 'i=5019',
   MachineryItemState_StateMachineType_FromNotExecutingToOutOfService = 'i=5017',
   MachineryItemState_StateMachineType_FromOutOfServiceToExecuting = 'i=5014',
   MachineryItemState_StateMachineType_FromOutOfServiceToNotAvailable = 'i=5012',
   MachineryItemState_StateMachineType_FromOutOfServiceToNotExecuting = 'i=5013',
   MachineryItemState_StateMachineType_FromOutOfServiceToOutOfService = 'i=5015',
   MachineryItemState_StateMachineType_NotAvailable = 'i=5005',
   MachineryItemState_StateMachineType_NotExecuting = 'i=5007',
   MachineryItemState_StateMachineType_OutOfService = 'i=5004',
   Machines = 'i=1001'
}

export enum ObjectTypeIds {
   IMachineTagNameplateType = 'i=1011',
   IMachineryItemVendorNameplateType = 'i=1003',
   IMachineVendorNameplateType = 'i=1010',
   MachineryItemIdentificationType = 'i=1004',
   MachineIdentificationType = 'i=1012',
   MachineryComponentIdentificationType = 'i=1005',
   MachineComponentsType = 'i=1006',
   MachineryItemState_StateMachineType = 'i=1002',
   MachineryOperationModeStateMachineType = 'i=1008'
}

export enum VariableIds {
   MachineryItemState_StateMachineType_DefaultInstanceBrowseName = 'i=6021',
   MachineryItemState_StateMachineType_Executing_StateNumber = 'i=6040',
   MachineryItemState_StateMachineType_FromExecutingToExecuting_TransitionNumber = 'i=6057',
   MachineryItemState_StateMachineType_FromExecutingToNotAvailable_TransitionNumber = 'i=6054',
   MachineryItemState_StateMachineType_FromExecutingToNotExecuting_TransitionNumber = 'i=6056',
   MachineryItemState_StateMachineType_FromExecutingToOutOfService_TransitionNumber = 'i=6055',
   MachineryItemState_StateMachineType_FromNotAvailableToExecuting_TransitionNumber = 'i=6044',
   MachineryItemState_StateMachineType_FromNotAvailableToNotAvailable_TransitionNumber = 'i=6045',
   MachineryItemState_StateMachineType_FromNotAvailableToNotExecuting_TransitionNumber = 'i=6043',
   MachineryItemState_StateMachineType_FromNotAvailableToOutOfService_TransitionNumber = 'i=6042',
   MachineryItemState_StateMachineType_FromNotExecutingToExecuting_TransitionNumber = 'i=6052',
   MachineryItemState_StateMachineType_FromNotExecutingToNotAvailable_TransitionNumber = 'i=6050',
   MachineryItemState_StateMachineType_FromNotExecutingToNotExecuting_TransitionNumber = 'i=6053',
   MachineryItemState_StateMachineType_FromNotExecutingToOutOfService_TransitionNumber = 'i=6051',
   MachineryItemState_StateMachineType_FromOutOfServiceToExecuting_TransitionNumber = 'i=6048',
   MachineryItemState_StateMachineType_FromOutOfServiceToNotAvailable_TransitionNumber = 'i=6046',
   MachineryItemState_StateMachineType_FromOutOfServiceToNotExecuting_TransitionNumber = 'i=6047',
   MachineryItemState_StateMachineType_FromOutOfServiceToOutOfService_TransitionNumber = 'i=6049',
   MachineryItemState_StateMachineType_NotAvailable_StateNumber = 'i=6039',
   MachineryItemState_StateMachineType_NotExecuting_StateNumber = 'i=6041',
   MachineryItemState_StateMachineType_OutOfService_StateNumber = 'i=6038'
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


export enum MethodIds {
   HarnessMachineType_Start = 'i=187',
   HarnessMachineType_Stop = 'i=190',
   HarnessMachineType_AddPart = 'i=192',
   Machines_HarnessMachine_Start = 'i=340',
   Machines_HarnessMachine_Stop = 'i=343',
   Machines_HarnessMachine_AddPart = 'i=345'
}

export enum ObjectIds {
   Machines = 'i=195',
   Machines_HarnessMachine = 'i=196',
   Machines_HarnessMachine_MachineBuildingBlocks = 'i=197',
   Machines_HarnessMachine_MachineBuildingBlocks_Components = 'i=198',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit = 'i=199',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification = 'i=200',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState = 'i=223',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler = 'i=229',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification = 'i=230',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler = 'i=253',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification = 'i=254',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer = 'i=274',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification = 'i=275',
   Machines_HarnessMachine_MachineBuildingBlocks_Identification = 'i=295',
   Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState = 'i=312',
   Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode = 'i=326',
   Machines_Wires = 'i=348'
}

export enum ObjectTypeIds {
   SpecificationWireType = 'i=1',
   JobState = 'i=11',
   HarnessSubmachineType = 'i=25',
   HarnessMachineType = 'i=43'
}

export enum VariableIds {
   JobState_JobKey = 'i=12',
   JobState_JobName = 'i=13',
   JobState_ArticleKey = 'i=14',
   JobState_ArticleName = 'i=15',
   JobState_State = 'i=16',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_Manufacturer = 'i=207',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_SerialNumber = 'i=213',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_DeviceRevision = 'i=216',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced = 'i=217',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced_EngineeringUnits = 'i=222',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobKey = 'i=224',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobName = 'i=225',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleKey = 'i=226',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleName = 'i=227',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_State = 'i=228',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_Manufacturer = 'i=237',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_SerialNumber = 'i=243',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_DeviceRevision = 'i=246',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber = 'i=247',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber_EngineeringUnits = 'i=252',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_Manufacturer = 'i=261',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_SerialNumber = 'i=267',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_DeviceRevision = 'i=270',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_LeadSetEnd = 'i=271',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_HousingName = 'i=272',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_CavityNumber = 'i=273',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_Manufacturer = 'i=282',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_SerialNumber = 'i=288',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_DeviceRevision = 'i=291',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper1 = 'i=292',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper2 = 'i=293',
   Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper3 = 'i=294',
   Machines_HarnessMachine_MachineBuildingBlocks_Identification_AssetId = 'i=297',
   Machines_HarnessMachine_MachineBuildingBlocks_Identification_Manufacturer = 'i=302',
   Machines_HarnessMachine_MachineBuildingBlocks_Identification_ProductInstanceUri = 'i=307',
   Machines_HarnessMachine_MachineBuildingBlocks_Identification_SerialNumber = 'i=308',
   Machines_HarnessMachine_MachineBuildingBlocks_Identification_YearOfConstruction = 'i=310',
   Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_CurrentState = 'i=313',
   Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_CurrentState_Id = 'i=314',
   Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_LastTransition_Id = 'i=319',
   Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_CurrentState = 'i=327',
   Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_CurrentState_Id = 'i=328',
   Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_LastTransition_Id = 'i=333',
   Machines_HarnessMachine_Start_InputArguments = 'i=341',
   Machines_HarnessMachine_Start_OutputArguments = 'i=342',
   Machines_HarnessMachine_Stop_OutputArguments = 'i=344',
   Machines_HarnessMachine_AddPart_InputArguments = 'i=346',
   Machines_HarnessMachine_AddPart_OutputArguments = 'i=347'
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
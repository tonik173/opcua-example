/* ========================================================================
 * Copyright (c) 2005-2024 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;
using Opc.Ua.DI;
using Opc.Ua.Machinery;

namespace HarnessMachine
{
    #region Method Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <remarks />
        public const uint HarnessMachineType_Start = 187;

        /// <remarks />
        public const uint HarnessMachineType_Stop = 190;

        /// <remarks />
        public const uint HarnessMachineType_AddPart = 192;

        /// <remarks />
        public const uint Machines_HarnessMachine_Start = 340;

        /// <remarks />
        public const uint Machines_HarnessMachine_Stop = 343;

        /// <remarks />
        public const uint Machines_HarnessMachine_AddPart = 345;
    }
    #endregion

    #region Object Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <remarks />
        public const uint HarnessSubmachineType_Identification = 26;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks = 44;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components = 45;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit = 46;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification = 47;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState = 70;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler = 76;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification = 77;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler = 100;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification = 101;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer = 121;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification = 122;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification = 142;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_MachineryItemState = 159;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode = 173;

        /// <remarks />
        public const uint Machines = 195;

        /// <remarks />
        public const uint Machines_HarnessMachine = 196;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks = 197;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components = 198;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit = 199;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification = 200;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState = 223;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler = 229;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification = 230;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler = 253;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification = 254;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer = 274;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification = 275;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Identification = 295;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState = 312;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode = 326;

        /// <remarks />
        public const uint Machines_Wires = 348;
    }
    #endregion

    #region ObjectType Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <remarks />
        public const uint SpecificationWireType = 1;

        /// <remarks />
        public const uint JobState = 11;

        /// <remarks />
        public const uint HarnessSubmachineType = 25;

        /// <remarks />
        public const uint HarnessMachineType = 43;
    }
    #endregion

    #region Variable Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <remarks />
        public const uint SpecificationWireType_Diameter = 2;

        /// <remarks />
        public const uint SpecificationWireType_NominalCrossSection = 3;

        /// <remarks />
        public const uint SpecificationWireType_Color = 4;

        /// <remarks />
        public const uint SpecificationWireType_NumberOfStrands = 5;

        /// <remarks />
        public const uint SpecificationWireType_NumberOfStrands_EURange = 9;

        /// <remarks />
        public const uint JobState_JobKey = 12;

        /// <remarks />
        public const uint JobState_JobName = 13;

        /// <remarks />
        public const uint JobState_ArticleKey = 14;

        /// <remarks />
        public const uint JobState_ArticleName = 15;

        /// <remarks />
        public const uint JobState_State = 16;

        /// <remarks />
        public const uint HarnessSubmachineType_Identification_Manufacturer = 33;

        /// <remarks />
        public const uint HarnessSubmachineType_Identification_SerialNumber = 39;

        /// <remarks />
        public const uint HarnessSubmachineType_Identification_DeviceRevision = 42;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification_Manufacturer = 54;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification_SerialNumber = 60;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification_DeviceRevision = 63;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced = 64;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced_EngineeringUnits = 69;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobKey = 71;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobName = 72;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleKey = 73;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleName = 74;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_State = 75;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_Manufacturer = 84;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_SerialNumber = 90;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_DeviceRevision = 93;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber = 94;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber_EngineeringUnits = 99;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification_Manufacturer = 108;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification_SerialNumber = 114;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification_DeviceRevision = 117;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_LeadSetEnd = 118;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_HousingName = 119;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_CavityNumber = 120;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification_Manufacturer = 129;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification_SerialNumber = 135;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification_DeviceRevision = 138;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Gripper1 = 139;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Gripper2 = 140;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Gripper3 = 141;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_AssetId = 144;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_ComponentName = 145;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_DeviceClass = 146;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_HardwareRevision = 147;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_InitialOperationDate = 148;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_Manufacturer = 149;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_ManufacturerUri = 150;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_Model = 151;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_MonthOfConstruction = 152;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_ProductCode = 153;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_ProductInstanceUri = 154;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_SerialNumber = 155;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_SoftwareRevision = 156;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_YearOfConstruction = 157;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_Identification_Location = 158;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_MachineryItemState_CurrentState = 160;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_MachineryItemState_CurrentState_Id = 161;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_MachineryItemState_LastTransition_Id = 166;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode_CurrentState = 174;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode_CurrentState_Id = 175;

        /// <remarks />
        public const uint HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode_LastTransition_Id = 180;

        /// <remarks />
        public const uint HarnessMachineType_Start_InputArguments = 188;

        /// <remarks />
        public const uint HarnessMachineType_Start_OutputArguments = 189;

        /// <remarks />
        public const uint HarnessMachineType_Stop_OutputArguments = 191;

        /// <remarks />
        public const uint HarnessMachineType_AddPart_InputArguments = 193;

        /// <remarks />
        public const uint HarnessMachineType_AddPart_OutputArguments = 194;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_Manufacturer = 207;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_SerialNumber = 213;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_DeviceRevision = 216;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced = 217;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced_EngineeringUnits = 222;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobKey = 224;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobName = 225;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleKey = 226;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleName = 227;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_State = 228;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_Manufacturer = 237;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_SerialNumber = 243;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_DeviceRevision = 246;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber = 247;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber_EngineeringUnits = 252;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_Manufacturer = 261;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_SerialNumber = 267;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_DeviceRevision = 270;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_LeadSetEnd = 271;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_HousingName = 272;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_CavityNumber = 273;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_Manufacturer = 282;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_SerialNumber = 288;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_DeviceRevision = 291;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper1 = 292;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper2 = 293;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper3 = 294;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Identification_AssetId = 297;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Identification_Manufacturer = 302;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Identification_ProductInstanceUri = 307;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Identification_SerialNumber = 308;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_Identification_YearOfConstruction = 310;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_CurrentState = 313;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_CurrentState_Id = 314;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_LastTransition_Id = 319;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_CurrentState = 327;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_CurrentState_Id = 328;

        /// <remarks />
        public const uint Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_LastTransition_Id = 333;

        /// <remarks />
        public const uint Machines_HarnessMachine_Start_InputArguments = 341;

        /// <remarks />
        public const uint Machines_HarnessMachine_Start_OutputArguments = 342;

        /// <remarks />
        public const uint Machines_HarnessMachine_Stop_OutputArguments = 344;

        /// <remarks />
        public const uint Machines_HarnessMachine_AddPart_InputArguments = 346;

        /// <remarks />
        public const uint Machines_HarnessMachine_AddPart_OutputArguments = 347;
    }
    #endregion

    #region Method Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_Start = new ExpandedNodeId(HarnessMachine.Methods.HarnessMachineType_Start, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_Stop = new ExpandedNodeId(HarnessMachine.Methods.HarnessMachineType_Stop, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_AddPart = new ExpandedNodeId(HarnessMachine.Methods.HarnessMachineType_AddPart, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_Start = new ExpandedNodeId(HarnessMachine.Methods.Machines_HarnessMachine_Start, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_Stop = new ExpandedNodeId(HarnessMachine.Methods.Machines_HarnessMachine_Stop, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_AddPart = new ExpandedNodeId(HarnessMachine.Methods.Machines_HarnessMachine_AddPart, HarnessMachine.Namespaces.HarnessMachine);
    }
    #endregion

    #region Object Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId HarnessSubmachineType_Identification = new ExpandedNodeId(HarnessMachine.Objects.HarnessSubmachineType_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Components, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_MachineryItemState = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_MachineryItemState, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode = new ExpandedNodeId(HarnessMachine.Objects.HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines = new ExpandedNodeId(HarnessMachine.Objects.Machines, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Components, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Identification = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_Identification, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode = new ExpandedNodeId(HarnessMachine.Objects.Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_Wires = new ExpandedNodeId(HarnessMachine.Objects.Machines_Wires, HarnessMachine.Namespaces.HarnessMachine);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId SpecificationWireType = new ExpandedNodeId(HarnessMachine.ObjectTypes.SpecificationWireType, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId JobState = new ExpandedNodeId(HarnessMachine.ObjectTypes.JobState, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessSubmachineType = new ExpandedNodeId(HarnessMachine.ObjectTypes.HarnessSubmachineType, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType = new ExpandedNodeId(HarnessMachine.ObjectTypes.HarnessMachineType, HarnessMachine.Namespaces.HarnessMachine);
    }
    #endregion

    #region Variable Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId SpecificationWireType_Diameter = new ExpandedNodeId(HarnessMachine.Variables.SpecificationWireType_Diameter, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId SpecificationWireType_NominalCrossSection = new ExpandedNodeId(HarnessMachine.Variables.SpecificationWireType_NominalCrossSection, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId SpecificationWireType_Color = new ExpandedNodeId(HarnessMachine.Variables.SpecificationWireType_Color, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId SpecificationWireType_NumberOfStrands = new ExpandedNodeId(HarnessMachine.Variables.SpecificationWireType_NumberOfStrands, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId SpecificationWireType_NumberOfStrands_EURange = new ExpandedNodeId(HarnessMachine.Variables.SpecificationWireType_NumberOfStrands_EURange, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId JobState_JobKey = new ExpandedNodeId(HarnessMachine.Variables.JobState_JobKey, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId JobState_JobName = new ExpandedNodeId(HarnessMachine.Variables.JobState_JobName, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId JobState_ArticleKey = new ExpandedNodeId(HarnessMachine.Variables.JobState_ArticleKey, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId JobState_ArticleName = new ExpandedNodeId(HarnessMachine.Variables.JobState_ArticleName, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId JobState_State = new ExpandedNodeId(HarnessMachine.Variables.JobState_State, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessSubmachineType_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.HarnessSubmachineType_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessSubmachineType_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.HarnessSubmachineType_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessSubmachineType_Identification_DeviceRevision = new ExpandedNodeId(HarnessMachine.Variables.HarnessSubmachineType_Identification_DeviceRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification_DeviceRevision = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_Identification_DeviceRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced_EngineeringUnits = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced_EngineeringUnits, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobKey = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobKey, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobName = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobName, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleKey = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleKey, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleName = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleName, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_State = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_CoordinationUnit_JobState_State, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_DeviceRevision = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_DeviceRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber_EngineeringUnits = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber_EngineeringUnits, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification_DeviceRevision = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_Identification_DeviceRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_LeadSetEnd = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_LeadSetEnd, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_HousingName = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_HousingName, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_CavityNumber = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessAssembler_CavityNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification_DeviceRevision = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Identification_DeviceRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Gripper1 = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Gripper1, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Gripper2 = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Gripper2, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Gripper3 = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Components_HarnessFoamer_Gripper3, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_AssetId = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_AssetId, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_ComponentName = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_ComponentName, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_DeviceClass = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_DeviceClass, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_HardwareRevision = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_HardwareRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_InitialOperationDate = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_InitialOperationDate, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_ManufacturerUri = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_ManufacturerUri, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_Model = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_Model, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_MonthOfConstruction = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_MonthOfConstruction, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_ProductCode = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_ProductCode, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_ProductInstanceUri = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_ProductInstanceUri, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_SoftwareRevision = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_SoftwareRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_YearOfConstruction = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_YearOfConstruction, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_Identification_Location = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_Identification_Location, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_MachineryItemState_CurrentState = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_MachineryItemState_CurrentState, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_MachineryItemState_CurrentState_Id = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_MachineryItemState_CurrentState_Id, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_MachineryItemState_LastTransition_Id = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_MachineryItemState_LastTransition_Id, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode_CurrentState = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode_CurrentState, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode_CurrentState_Id = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode_CurrentState_Id, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode_LastTransition_Id = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_MachineBuildingBlocks_MachineryOperationMode_LastTransition_Id, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_Start_InputArguments = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_Start_InputArguments, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_Start_OutputArguments = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_Start_OutputArguments, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_Stop_OutputArguments = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_Stop_OutputArguments, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_AddPart_InputArguments = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_AddPart_InputArguments, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId HarnessMachineType_AddPart_OutputArguments = new ExpandedNodeId(HarnessMachine.Variables.HarnessMachineType_AddPart_OutputArguments, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_DeviceRevision = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_Identification_DeviceRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced_EngineeringUnits = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_ItemsProduced_EngineeringUnits, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobKey = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobKey, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobName = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_JobName, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleKey = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleKey, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleName = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_ArticleName, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_State = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_CoordinationUnit_JobState_State, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_DeviceRevision = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_Identification_DeviceRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber_EngineeringUnits = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_LeadSetAssembler_LeadSetNumber_EngineeringUnits, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_DeviceRevision = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_Identification_DeviceRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_LeadSetEnd = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_LeadSetEnd, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_HousingName = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_HousingName, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_CavityNumber = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessAssembler_CavityNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_DeviceRevision = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Identification_DeviceRevision, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper1 = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper1, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper2 = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper2, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper3 = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Components_HarnessFoamer_Gripper3, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Identification_AssetId = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Identification_AssetId, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Identification_Manufacturer = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Identification_Manufacturer, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Identification_ProductInstanceUri = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Identification_ProductInstanceUri, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Identification_SerialNumber = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Identification_SerialNumber, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_Identification_YearOfConstruction = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_Identification_YearOfConstruction, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_CurrentState = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_CurrentState, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_CurrentState_Id = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_CurrentState_Id, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_LastTransition_Id = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_MachineryItemState_LastTransition_Id, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_CurrentState = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_CurrentState, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_CurrentState_Id = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_CurrentState_Id, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_LastTransition_Id = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_MachineBuildingBlocks_MachineryOperationMode_LastTransition_Id, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_Start_InputArguments = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_Start_InputArguments, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_Start_OutputArguments = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_Start_OutputArguments, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_Stop_OutputArguments = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_Stop_OutputArguments, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_AddPart_InputArguments = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_AddPart_InputArguments, HarnessMachine.Namespaces.HarnessMachine);

        /// <remarks />
        public static readonly ExpandedNodeId Machines_HarnessMachine_AddPart_OutputArguments = new ExpandedNodeId(HarnessMachine.Variables.Machines_HarnessMachine_AddPart_OutputArguments, HarnessMachine.Namespaces.HarnessMachine);
    }
    #endregion

    #region BrowseName Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <remarks />
        public const string AddPart = "AddPart";

        /// <remarks />
        public const string ArticleKey = "ArticleKey";

        /// <remarks />
        public const string ArticleName = "ArticleName";

        /// <remarks />
        public const string Color = "Color";

        /// <remarks />
        public const string Diameter = "Diameter";

        /// <remarks />
        public const string HarnessMachine = "HarnessMachine";

        /// <remarks />
        public const string HarnessMachineType = "HarnessMachineType";

        /// <remarks />
        public const string HarnessSubmachineType = "HarnessSubmachineType";

        /// <remarks />
        public const string Identification = "Identification";

        /// <remarks />
        public const string JobKey = "JobKey";

        /// <remarks />
        public const string JobName = "JobName";

        /// <remarks />
        public const string JobState = "JobState";

        /// <remarks />
        public const string MachineBuildingBlocks = "MachineBuildingBlocks";

        /// <remarks />
        public const string Machines = "Machines";

        /// <remarks />
        public const string NominalCrossSection = "NominalCrossSection";

        /// <remarks />
        public const string NumberOfStrands = "NumberOfStrands";

        /// <remarks />
        public const string SpecificationWireType = "SpecificationWireType";

        /// <remarks />
        public const string Start = "Start";

        /// <remarks />
        public const string State = "State";

        /// <remarks />
        public const string Stop = "Stop";

        /// <remarks />
        public const string Wires = "Wires";
    }
    #endregion

    #region Namespace Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the HarnessMachine namespace (.NET code namespace is 'HarnessMachine').
        /// </summary>
        public const string HarnessMachine = "http://example.com/HarnessMachine";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the DI namespace (.NET code namespace is 'Opc.Ua.DI').
        /// </summary>
        public const string DI = "http://opcfoundation.org/UA/DI/";

        /// <summary>
        /// The URI for the DIXsd namespace (.NET code namespace is 'Opc.Ua.DI').
        /// </summary>
        public const string DIXsd = "http://opcfoundation.org/UA/DI/Types.xsd";

        /// <summary>
        /// The URI for the Machinery namespace (.NET code namespace is 'Opc.Ua.Machinery').
        /// </summary>
        public const string Machinery = "http://opcfoundation.org/UA/Machinery/";

        /// <summary>
        /// The URI for the MachineryXsd namespace (.NET code namespace is 'Opc.Ua.Machinery').
        /// </summary>
        public const string MachineryXsd = "http://opcfoundation.org/UA/Machinery/Types.xsd";
    }
    #endregion
}
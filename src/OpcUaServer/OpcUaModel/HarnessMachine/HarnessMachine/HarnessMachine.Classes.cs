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
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;
using Opc.Ua.DI;
using Opc.Ua.Machinery;

namespace HarnessMachine
{
    #region SpecificationWireState Class
    #if (!OPCUA_EXCLUDE_SpecificationWireState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class SpecificationWireState : BaseObjectState
    {
        #region Constructors
        /// <remarks />
        public SpecificationWireState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(HarnessMachine.ObjectTypes.SpecificationWireType, HarnessMachine.Namespaces.HarnessMachine, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);

            if (Color != null)
            {
                Color.Initialize(context, Color_InitializationString);
            }
        }

        #region Initialization String
        private const string Color_InitializationString =
           "AwAAACEAAABodHRwOi8vZXhhbXBsZS5jb20vSGFybmVzc01hY2hpbmUfAAAAaHR0cDovL29wY2ZvdW5k" +
           "YXRpb24ub3JnL1VBL0RJLyYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvTWFjaGluZXJ5L///" +
           "//8VYIkKAgAAAAEABQAAAENvbG9yAQEEAAAuAEQEAAAAAQCqHf////8DA/////8AAAAA";

        private const string InitializationString =
           "AwAAACEAAABodHRwOi8vZXhhbXBsZS5jb20vSGFybmVzc01hY2hpbmUfAAAAaHR0cDovL29wY2ZvdW5k" +
           "YXRpb24ub3JnL1VBL0RJLyYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvTWFjaGluZXJ5L///" +
           "//+EYIACAQAAAAEAHQAAAFNwZWNpZmljYXRpb25XaXJlVHlwZUluc3RhbmNlAQEBAAEBAQABAAAAAf//" +
           "//8EAAAAFWCJCgIAAAABAAgAAABEaWFtZXRlcgEBAgAALgBEAgAAAAAL/////wMD/////wAAAAAVYIkK" +
           "AgAAAAEAEwAAAE5vbWluYWxDcm9zc1NlY3Rpb24BAQMAAC4ARAMAAAAAC/////8DA/////8AAAAAFWCJ" +
           "CgIAAAABAAUAAABDb2xvcgEBBAAALgBEBAAAAAEAqh3/////AwP/////AAAAABVgiQoCAAAAAQAPAAAA" +
           "TnVtYmVyT2ZTdHJhbmRzAQEFAAAvAQBACQUAAAAAC/////8BAf////8BAAAAFWCJCgIAAAAAAAcAAABF" +
           "VVJhbmdlAQEJAAAuAEQJAAAAAQB0A/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PropertyState<double> Diameter
        {
            get
            {
                return m_diameter;
            }

            set
            {
                if (!Object.ReferenceEquals(m_diameter, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_diameter = value;
            }
        }

        /// <remarks />
        public PropertyState<double> NominalCrossSection
        {
            get
            {
                return m_nominalCrossSection;
            }

            set
            {
                if (!Object.ReferenceEquals(m_nominalCrossSection, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_nominalCrossSection = value;
            }
        }

        /// <remarks />
        public PropertyState<EnumValueType> Color
        {
            get
            {
                return m_color;
            }

            set
            {
                if (!Object.ReferenceEquals(m_color, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_color = value;
            }
        }

        /// <remarks />
        public AnalogItemState<double> NumberOfStrands
        {
            get
            {
                return m_numberOfStrands;
            }

            set
            {
                if (!Object.ReferenceEquals(m_numberOfStrands, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_numberOfStrands = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_diameter != null)
            {
                children.Add(m_diameter);
            }

            if (m_nominalCrossSection != null)
            {
                children.Add(m_nominalCrossSection);
            }

            if (m_color != null)
            {
                children.Add(m_color);
            }

            if (m_numberOfStrands != null)
            {
                children.Add(m_numberOfStrands);
            }

            base.GetChildren(context, children);
        }
            
        /// <remarks />
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case HarnessMachine.BrowseNames.Diameter:
                {
                    if (createOrReplace)
                    {
                        if (Diameter == null)
                        {
                            if (replacement == null)
                            {
                                Diameter = new PropertyState<double>(this);
                            }
                            else
                            {
                                Diameter = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = Diameter;
                    break;
                }

                case HarnessMachine.BrowseNames.NominalCrossSection:
                {
                    if (createOrReplace)
                    {
                        if (NominalCrossSection == null)
                        {
                            if (replacement == null)
                            {
                                NominalCrossSection = new PropertyState<double>(this);
                            }
                            else
                            {
                                NominalCrossSection = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = NominalCrossSection;
                    break;
                }

                case HarnessMachine.BrowseNames.Color:
                {
                    if (createOrReplace)
                    {
                        if (Color == null)
                        {
                            if (replacement == null)
                            {
                                Color = new PropertyState<EnumValueType>(this);
                            }
                            else
                            {
                                Color = (PropertyState<EnumValueType>)replacement;
                            }
                        }
                    }

                    instance = Color;
                    break;
                }

                case HarnessMachine.BrowseNames.NumberOfStrands:
                {
                    if (createOrReplace)
                    {
                        if (NumberOfStrands == null)
                        {
                            if (replacement == null)
                            {
                                NumberOfStrands = new AnalogItemState<double>(this);
                            }
                            else
                            {
                                NumberOfStrands = (AnalogItemState<double>)replacement;
                            }
                        }
                    }

                    instance = NumberOfStrands;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<double> m_diameter;
        private PropertyState<double> m_nominalCrossSection;
        private PropertyState<EnumValueType> m_color;
        private AnalogItemState<double> m_numberOfStrands;
        #endregion
    }
    #endif
    #endregion

    #region JobStateState Class
    #if (!OPCUA_EXCLUDE_JobStateState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class JobStateState : BaseObjectState
    {
        #region Constructors
        /// <remarks />
        public JobStateState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(HarnessMachine.ObjectTypes.JobState, HarnessMachine.Namespaces.HarnessMachine, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AwAAACEAAABodHRwOi8vZXhhbXBsZS5jb20vSGFybmVzc01hY2hpbmUfAAAAaHR0cDovL29wY2ZvdW5k" +
           "YXRpb24ub3JnL1VBL0RJLyYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvTWFjaGluZXJ5L///" +
           "//+EYIACAQAAAAEAEAAAAEpvYlN0YXRlSW5zdGFuY2UBAQsAAQELAAsAAAAB/////wUAAAAVYIkKAgAA" +
           "AAEABgAAAEpvYktleQEBDAAALwA/DAAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEABwAAAEpvYk5h" +
           "bWUBAQ0AAC8APw0AAAAADP////8BAf////8AAAAAFWCJCgIAAAABAAoAAABBcnRpY2xlS2V5AQEOAAAv" +
           "AD8OAAAAAAz/////AQH/////AAAAABVgiQoCAAAAAQALAAAAQXJ0aWNsZU5hbWUBAQ8AAC8APw8AAAAA" +
           "DP////8BAf////8AAAAAFWCJCgIAAAABAAUAAABTdGF0ZQEBEAAALwA/EAAAAAAM/////wEB/////wAA" +
           "AAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<string> JobKey
        {
            get
            {
                return m_jobKey;
            }

            set
            {
                if (!Object.ReferenceEquals(m_jobKey, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_jobKey = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<string> JobName
        {
            get
            {
                return m_jobName;
            }

            set
            {
                if (!Object.ReferenceEquals(m_jobName, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_jobName = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<string> ArticleKey
        {
            get
            {
                return m_articleKey;
            }

            set
            {
                if (!Object.ReferenceEquals(m_articleKey, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_articleKey = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<string> ArticleName
        {
            get
            {
                return m_articleName;
            }

            set
            {
                if (!Object.ReferenceEquals(m_articleName, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_articleName = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<string> State
        {
            get
            {
                return m_state;
            }

            set
            {
                if (!Object.ReferenceEquals(m_state, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_state = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_jobKey != null)
            {
                children.Add(m_jobKey);
            }

            if (m_jobName != null)
            {
                children.Add(m_jobName);
            }

            if (m_articleKey != null)
            {
                children.Add(m_articleKey);
            }

            if (m_articleName != null)
            {
                children.Add(m_articleName);
            }

            if (m_state != null)
            {
                children.Add(m_state);
            }

            base.GetChildren(context, children);
        }
            
        /// <remarks />
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case HarnessMachine.BrowseNames.JobKey:
                {
                    if (createOrReplace)
                    {
                        if (JobKey == null)
                        {
                            if (replacement == null)
                            {
                                JobKey = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                JobKey = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = JobKey;
                    break;
                }

                case HarnessMachine.BrowseNames.JobName:
                {
                    if (createOrReplace)
                    {
                        if (JobName == null)
                        {
                            if (replacement == null)
                            {
                                JobName = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                JobName = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = JobName;
                    break;
                }

                case HarnessMachine.BrowseNames.ArticleKey:
                {
                    if (createOrReplace)
                    {
                        if (ArticleKey == null)
                        {
                            if (replacement == null)
                            {
                                ArticleKey = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                ArticleKey = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = ArticleKey;
                    break;
                }

                case HarnessMachine.BrowseNames.ArticleName:
                {
                    if (createOrReplace)
                    {
                        if (ArticleName == null)
                        {
                            if (replacement == null)
                            {
                                ArticleName = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                ArticleName = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = ArticleName;
                    break;
                }

                case HarnessMachine.BrowseNames.State:
                {
                    if (createOrReplace)
                    {
                        if (State == null)
                        {
                            if (replacement == null)
                            {
                                State = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                State = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = State;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<string> m_jobKey;
        private BaseDataVariableState<string> m_jobName;
        private BaseDataVariableState<string> m_articleKey;
        private BaseDataVariableState<string> m_articleName;
        private BaseDataVariableState<string> m_state;
        #endregion
    }
    #endif
    #endregion

    #region AddPartMethodState Class
    #if (!OPCUA_EXCLUDE_AddPartMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AddPartMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public AddPartMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new AddPartMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AwAAACEAAABodHRwOi8vZXhhbXBsZS5jb20vSGFybmVzc01hY2hpbmUfAAAAaHR0cDovL29wY2ZvdW5k" +
           "YXRpb24ub3JnL1VBL0RJLyYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvTWFjaGluZXJ5L///" +
           "//8EYYIKBAAAAAEAEQAAAEFkZFBhcnRNZXRob2RUeXBlAQERAAAvAQERABEAAAABAf////8CAAAAF2Cp" +
           "CgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBEgAALgBEEgAAAJYBAAAAAQAqAQEqAAAABAAAAFBhcnQA" +
           "DP////8AAAAAAwAAAAAPAAAAQSBtYXRlcmlhbCB0eXBlAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAX" +
           "YKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBEwAALgBEEwAAAJYBAAAAAQAqAQE3AAAABgAAAFJl" +
           "c3VsdAAG/////wAAAAADAAAAABoAAABOZWdhdGl2ZSBudW1iZXIgYXJlIGVycm9ycwEAKAEBAAAAAQAA" +
           "AAEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public AddPartMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            string part = (string)_inputArguments[0];

            int result = (int)_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    part,
                    ref result);
            }

            _outputArguments[0] = result;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult AddPartMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        string part,
        ref int result);
    #endif
    #endregion

    #region StartMethodState Class
    #if (!OPCUA_EXCLUDE_StartMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class StartMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public StartMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new StartMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AwAAACEAAABodHRwOi8vZXhhbXBsZS5jb20vSGFybmVzc01hY2hpbmUfAAAAaHR0cDovL29wY2ZvdW5k" +
           "YXRpb24ub3JnL1VBL0RJLyYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvTWFjaGluZXJ5L///" +
           "//8EYYIKBAAAAAEADwAAAFN0YXJ0TWV0aG9kVHlwZQEBFAAALwEBFAAUAAAAAQH/////AgAAABdgqQoC" +
           "AAAAAAAOAAAASW5wdXRBcmd1bWVudHMBARUAAC4ARBUAAACWAgAAAAEAKgEBQAAAAAkAAABBcnRpY2xl" +
           "SUQADP////8AAAAAAwAAAAAgAAAAVGhlIGlkIG9mIHRoZSBhcnRpY2xlIHRvIHByb2R1Y2UBACoBATYA" +
           "AAAFAAAASXRlbXMABv////8AAAAAAwAAAAAaAAAATnVtYmVyIG9mIGl0ZW1zIHRvIHByb2R1Y2UBACgB" +
           "AQAAAAEAAAACAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQEWAAAuAEQW" +
           "AAAAlgEAAAABACoBATcAAAAGAAAAUmVzdWx0AAb/////AAAAAAMAAAAAGgAAAE5lZ2F0aXZlIG51bWJl" +
           "ciBhcmUgZXJyb3JzAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public StartMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            string articleID = (string)_inputArguments[0];
            int items = (int)_inputArguments[1];

            int result = (int)_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    articleID,
                    items,
                    ref result);
            }

            _outputArguments[0] = result;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult StartMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        string articleID,
        int items,
        ref int result);
    #endif
    #endregion

    #region StopMethodState Class
    #if (!OPCUA_EXCLUDE_StopMethodState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class StopMethodState : MethodState
    {
        #region Constructors
        /// <remarks />
        public StopMethodState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        public new static NodeState Construct(NodeState parent)
        {
            return new StopMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AwAAACEAAABodHRwOi8vZXhhbXBsZS5jb20vSGFybmVzc01hY2hpbmUfAAAAaHR0cDovL29wY2ZvdW5k" +
           "YXRpb24ub3JnL1VBL0RJLyYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvTWFjaGluZXJ5L///" +
           "//8EYYIKBAAAAAEADgAAAFN0b3BNZXRob2RUeXBlAQEXAAAvAQEXABcAAAABAf////8BAAAAF2CpCgIA" +
           "AAAAAA8AAABPdXRwdXRBcmd1bWVudHMBARgAAC4ARBgAAACWAQAAAAEAKgEBNwAAAAYAAABSZXN1bHQA" +
           "Bv////8AAAAAAwAAAAAaAAAATmVnYXRpdmUgbnVtYmVyIGFyZSBlcnJvcnMBACgBAQAAAAEAAAABAAAA" +
           "AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <remarks />
        public StopMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <remarks />
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult _result = null;

            int result = (int)_outputArguments[0];

            if (OnCall != null)
            {
                _result = OnCall(
                    _context,
                    this,
                    _objectId,
                    ref result);
            }

            _outputArguments[0] = result;

            return _result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <remarks />
    /// <exclude />
    public delegate ServiceResult StopMethodStateMethodCallHandler(
        ISystemContext _context,
        MethodState _method,
        NodeId _objectId,
        ref int result);
    #endif
    #endregion

    #region HarnessSubmachineState Class
    #if (!OPCUA_EXCLUDE_HarnessSubmachineState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class HarnessSubmachineState : BaseObjectState
    {
        #region Constructors
        /// <remarks />
        public HarnessSubmachineState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(HarnessMachine.ObjectTypes.HarnessSubmachineType, HarnessMachine.Namespaces.HarnessMachine, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AwAAACEAAABodHRwOi8vZXhhbXBsZS5jb20vSGFybmVzc01hY2hpbmUfAAAAaHR0cDovL29wY2ZvdW5k" +
           "YXRpb24ub3JnL1VBL0RJLyYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvTWFjaGluZXJ5L///" +
           "//+EYIACAQAAAAEAHQAAAEhhcm5lc3NTdWJtYWNoaW5lVHlwZUluc3RhbmNlAQEZAAEBGQAZAAAAAf//" +
           "//8BAAAABGCACgEAAAABAA4AAABJZGVudGlmaWNhdGlvbgEBGgAALwED7QMaAAAA/////wMAAAA1YIkK" +
           "AgAAAAIADAAAAE1hbnVmYWN0dXJlcgEBIQADAAAAAEoAAABBIGh1bWFuLXJlYWRhYmxlLCBsb2NhbGl6" +
           "ZWQgbmFtZSBvZiB0aGUgbWFudWZhY3R1cmVyIG9mIHRoZSBNYWNoaW5lcnlJdGVtLgAuAEQhAAAAABX/" +
           "////AQH/////AAAAADVgiQoCAAAAAgAMAAAAU2VyaWFsTnVtYmVyAQEnAAMAAAAAFwEAAEEgc3RyaW5n" +
           "IGNvbnRhaW5pbmcgYSB1bmlxdWUgcHJvZHVjdGlvbiBudW1iZXIgb2YgdGhlIG1hbnVmYWN0dXJlciBv" +
           "ZiB0aGUgTWFjaGluZXJ5SXRlbS4gVGhlIGdsb2JhbCB1bmlxdWVuZXNzIG9mIHRoZSBzZXJpYWwgbnVt" +
           "YmVyIGlzIG9ubHkgZ2l2ZW4gaW4gdGhlIGNvbnRleHQgb2YgdGhlIG1hbnVmYWN0dXJlciwgYW5kIHBv" +
           "dGVudGlhbGx5IHRoZSBtb2RlbC4gVGhlIHZhbHVlIHNoYWxsIG5vdCBjaGFuZ2UgZHVyaW5nIHRoZSBs" +
           "aWZlLWN5Y2xlIG9mIHRoZSBNYWNoaW5lcnlJdGVtLgAuAEQnAAAAAAz/////AQH/////AAAAADVgiQoC" +
           "AAAAAQAOAAAARGV2aWNlUmV2aXNpb24BASoAAwAAAAAIAQAAQSBzdHJpbmcgcmVwcmVzZW50YXRpb24g" +
           "b2YgdGhlIG92ZXJhbGwgcmV2aXNpb24gbGV2ZWwgb2YgdGhlIGNvbXBvbmVudC4gT2Z0ZW4sIGl0IGlz" +
           "IGluY3JlYXNlZCB3aGVuIGVpdGhlciB0aGUgU29mdHdhcmVSZXZpc2lvbiBhbmQgLyBvciB0aGUgSGFy" +
           "ZHdhcmVSZXZpc2lvbiBvZiB0aGUgY29tcG9uZW50IGlzIGluY3JlYXNlZC4gQXMgYW4gZXhhbXBsZSwg" +
           "aXQgY2FuIGJlIHVzZWQgaW4gRVJQIHN5c3RlbXMgdG9nZXRoZXIgd2l0aCB0aGUgUHJvZHVjdENvZGUu" +
           "AC4ARCoAAAAADP////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public MachineryComponentIdentificationTypeState Identification
        {
            get
            {
                return m_identification;
            }

            set
            {
                if (!Object.ReferenceEquals(m_identification, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_identification = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_identification != null)
            {
                children.Add(m_identification);
            }

            base.GetChildren(context, children);
        }
            
        /// <remarks />
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case HarnessMachine.BrowseNames.Identification:
                {
                    if (createOrReplace)
                    {
                        if (Identification == null)
                        {
                            if (replacement == null)
                            {
                                Identification = new MachineryComponentIdentificationTypeState(this);
                            }
                            else
                            {
                                Identification = (MachineryComponentIdentificationTypeState)replacement;
                            }
                        }
                    }

                    instance = Identification;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private MachineryComponentIdentificationTypeState m_identification;
        #endregion
    }
    #endif
    #endregion

    #region HarnessMachineState Class
    #if (!OPCUA_EXCLUDE_HarnessMachineState)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class HarnessMachineState : BaseObjectState
    {
        #region Constructors
        /// <remarks />
        public HarnessMachineState(NodeState parent) : base(parent)
        {
        }

        /// <remarks />
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(HarnessMachine.ObjectTypes.HarnessMachineType, HarnessMachine.Namespaces.HarnessMachine, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <remarks />
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <remarks />
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <remarks />
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AwAAACEAAABodHRwOi8vZXhhbXBsZS5jb20vSGFybmVzc01hY2hpbmUfAAAAaHR0cDovL29wY2ZvdW5k" +
           "YXRpb24ub3JnL1VBL0RJLyYAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvTWFjaGluZXJ5L///" +
           "//+EYIACAQAAAAEAGgAAAEhhcm5lc3NNYWNoaW5lVHlwZUluc3RhbmNlAQErAAEBKwArAAAAAQIAAAAA" +
           "LwABAS0AAC8AAQGOAAQAAAAEYIAKAQAAAAEAFQAAAE1hY2hpbmVCdWlsZGluZ0Jsb2NrcwEBLAAALwA9" +
           "LAAAAP////8EAAAABGCACgEAAAABAAoAAABDb21wb25lbnRzAQEtAAAvAQPuAy0AAAABAAAAAC8BAQEr" +
           "AAQAAAAEYIAKAQAAAAEAEAAAAENvb3JkaW5hdGlvblVuaXQBAS4AAC8BARkALgAAAP////8DAAAABGCA" +
           "CgEAAAABAA4AAABJZGVudGlmaWNhdGlvbgEBLwAALwED7QMvAAAA/////wMAAAA1YIkKAgAAAAIADAAA" +
           "AE1hbnVmYWN0dXJlcgEBNgADAAAAAEoAAABBIGh1bWFuLXJlYWRhYmxlLCBsb2NhbGl6ZWQgbmFtZSBv" +
           "ZiB0aGUgbWFudWZhY3R1cmVyIG9mIHRoZSBNYWNoaW5lcnlJdGVtLgAuAEQ2AAAAABX/////AQH/////" +
           "AAAAADVgiQoCAAAAAgAMAAAAU2VyaWFsTnVtYmVyAQE8AAMAAAAAFwEAAEEgc3RyaW5nIGNvbnRhaW5p" +
           "bmcgYSB1bmlxdWUgcHJvZHVjdGlvbiBudW1iZXIgb2YgdGhlIG1hbnVmYWN0dXJlciBvZiB0aGUgTWFj" +
           "aGluZXJ5SXRlbS4gVGhlIGdsb2JhbCB1bmlxdWVuZXNzIG9mIHRoZSBzZXJpYWwgbnVtYmVyIGlzIG9u" +
           "bHkgZ2l2ZW4gaW4gdGhlIGNvbnRleHQgb2YgdGhlIG1hbnVmYWN0dXJlciwgYW5kIHBvdGVudGlhbGx5" +
           "IHRoZSBtb2RlbC4gVGhlIHZhbHVlIHNoYWxsIG5vdCBjaGFuZ2UgZHVyaW5nIHRoZSBsaWZlLWN5Y2xl" +
           "IG9mIHRoZSBNYWNoaW5lcnlJdGVtLgAuAEQ8AAAAAAz/////AQH/////AAAAADVgiQoCAAAAAQAOAAAA" +
           "RGV2aWNlUmV2aXNpb24BAT8AAwAAAAAIAQAAQSBzdHJpbmcgcmVwcmVzZW50YXRpb24gb2YgdGhlIG92" +
           "ZXJhbGwgcmV2aXNpb24gbGV2ZWwgb2YgdGhlIGNvbXBvbmVudC4gT2Z0ZW4sIGl0IGlzIGluY3JlYXNl" +
           "ZCB3aGVuIGVpdGhlciB0aGUgU29mdHdhcmVSZXZpc2lvbiBhbmQgLyBvciB0aGUgSGFyZHdhcmVSZXZp" +
           "c2lvbiBvZiB0aGUgY29tcG9uZW50IGlzIGluY3JlYXNlZC4gQXMgYW4gZXhhbXBsZSwgaXQgY2FuIGJl" +
           "IHVzZWQgaW4gRVJQIHN5c3RlbXMgdG9nZXRoZXIgd2l0aCB0aGUgUHJvZHVjdENvZGUuAC4ARD8AAAAA" +
           "DP////8BAf////8AAAAAFWCJCgIAAAABAA0AAABJdGVtc1Byb2R1Y2VkAQFAAAAvAQBZREAAAAAABv//" +
           "//8BAf////8BAAAAFWCJCgIAAAAAABAAAABFbmdpbmVlcmluZ1VuaXRzAQFFAAAuAERFAAAAAQB3A///" +
           "//8BAf////8AAAAABGCACgEAAAABAAgAAABKb2JTdGF0ZQEBRgAALwEBCwBGAAAA/////wUAAAAVYIkK" +
           "AgAAAAEABgAAAEpvYktleQEBRwAALwA/RwAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEABwAAAEpv" +
           "Yk5hbWUBAUgAAC8AP0gAAAAADP////8BAf////8AAAAAFWCJCgIAAAABAAoAAABBcnRpY2xlS2V5AQFJ" +
           "AAAvAD9JAAAAAAz/////AQH/////AAAAABVgiQoCAAAAAQALAAAAQXJ0aWNsZU5hbWUBAUoAAC8AP0oA" +
           "AAAADP////8BAf////8AAAAAFWCJCgIAAAABAAUAAABTdGF0ZQEBSwAALwA/SwAAAAAM/////wEB////" +
           "/wAAAAAEYIAKAQAAAAEAEAAAAExlYWRTZXRBc3NlbWJsZXIBAUwAAC8BARkATAAAAP////8CAAAABGCA" +
           "CgEAAAABAA4AAABJZGVudGlmaWNhdGlvbgEBTQAALwED7QNNAAAA/////wMAAAA1YIkKAgAAAAIADAAA" +
           "AE1hbnVmYWN0dXJlcgEBVAADAAAAAEoAAABBIGh1bWFuLXJlYWRhYmxlLCBsb2NhbGl6ZWQgbmFtZSBv" +
           "ZiB0aGUgbWFudWZhY3R1cmVyIG9mIHRoZSBNYWNoaW5lcnlJdGVtLgAuAERUAAAAABX/////AQH/////" +
           "AAAAADVgiQoCAAAAAgAMAAAAU2VyaWFsTnVtYmVyAQFaAAMAAAAAFwEAAEEgc3RyaW5nIGNvbnRhaW5p" +
           "bmcgYSB1bmlxdWUgcHJvZHVjdGlvbiBudW1iZXIgb2YgdGhlIG1hbnVmYWN0dXJlciBvZiB0aGUgTWFj" +
           "aGluZXJ5SXRlbS4gVGhlIGdsb2JhbCB1bmlxdWVuZXNzIG9mIHRoZSBzZXJpYWwgbnVtYmVyIGlzIG9u" +
           "bHkgZ2l2ZW4gaW4gdGhlIGNvbnRleHQgb2YgdGhlIG1hbnVmYWN0dXJlciwgYW5kIHBvdGVudGlhbGx5" +
           "IHRoZSBtb2RlbC4gVGhlIHZhbHVlIHNoYWxsIG5vdCBjaGFuZ2UgZHVyaW5nIHRoZSBsaWZlLWN5Y2xl" +
           "IG9mIHRoZSBNYWNoaW5lcnlJdGVtLgAuAERaAAAAAAz/////AQH/////AAAAADVgiQoCAAAAAQAOAAAA" +
           "RGV2aWNlUmV2aXNpb24BAV0AAwAAAAAIAQAAQSBzdHJpbmcgcmVwcmVzZW50YXRpb24gb2YgdGhlIG92" +
           "ZXJhbGwgcmV2aXNpb24gbGV2ZWwgb2YgdGhlIGNvbXBvbmVudC4gT2Z0ZW4sIGl0IGlzIGluY3JlYXNl" +
           "ZCB3aGVuIGVpdGhlciB0aGUgU29mdHdhcmVSZXZpc2lvbiBhbmQgLyBvciB0aGUgSGFyZHdhcmVSZXZp" +
           "c2lvbiBvZiB0aGUgY29tcG9uZW50IGlzIGluY3JlYXNlZC4gQXMgYW4gZXhhbXBsZSwgaXQgY2FuIGJl" +
           "IHVzZWQgaW4gRVJQIHN5c3RlbXMgdG9nZXRoZXIgd2l0aCB0aGUgUHJvZHVjdENvZGUuAC4ARF0AAAAA" +
           "DP////8BAf////8AAAAAFWCJCgIAAAABAA0AAABMZWFkU2V0TnVtYmVyAQFeAAAvAQBZRF4AAAAABv//" +
           "//8BAf////8BAAAAFWCJCgIAAAAAABAAAABFbmdpbmVlcmluZ1VuaXRzAQFjAAAuAERjAAAAAQB3A///" +
           "//8BAf////8AAAAABGCACgEAAAABABAAAABIYXJuZXNzQXNzZW1ibGVyAQFkAAAvAQEZAGQAAAD/////" +
           "BAAAAARggAoBAAAAAQAOAAAASWRlbnRpZmljYXRpb24BAWUAAC8BA+0DZQAAAP////8DAAAANWCJCgIA" +
           "AAACAAwAAABNYW51ZmFjdHVyZXIBAWwAAwAAAABKAAAAQSBodW1hbi1yZWFkYWJsZSwgbG9jYWxpemVk" +
           "IG5hbWUgb2YgdGhlIG1hbnVmYWN0dXJlciBvZiB0aGUgTWFjaGluZXJ5SXRlbS4ALgBEbAAAAAAV////" +
           "/wEB/////wAAAAA1YIkKAgAAAAIADAAAAFNlcmlhbE51bWJlcgEBcgADAAAAABcBAABBIHN0cmluZyBj" +
           "b250YWluaW5nIGEgdW5pcXVlIHByb2R1Y3Rpb24gbnVtYmVyIG9mIHRoZSBtYW51ZmFjdHVyZXIgb2Yg" +
           "dGhlIE1hY2hpbmVyeUl0ZW0uIFRoZSBnbG9iYWwgdW5pcXVlbmVzcyBvZiB0aGUgc2VyaWFsIG51bWJl" +
           "ciBpcyBvbmx5IGdpdmVuIGluIHRoZSBjb250ZXh0IG9mIHRoZSBtYW51ZmFjdHVyZXIsIGFuZCBwb3Rl" +
           "bnRpYWxseSB0aGUgbW9kZWwuIFRoZSB2YWx1ZSBzaGFsbCBub3QgY2hhbmdlIGR1cmluZyB0aGUgbGlm" +
           "ZS1jeWNsZSBvZiB0aGUgTWFjaGluZXJ5SXRlbS4ALgBEcgAAAAAM/////wEB/////wAAAAA1YIkKAgAA" +
           "AAEADgAAAERldmljZVJldmlzaW9uAQF1AAMAAAAACAEAAEEgc3RyaW5nIHJlcHJlc2VudGF0aW9uIG9m" +
           "IHRoZSBvdmVyYWxsIHJldmlzaW9uIGxldmVsIG9mIHRoZSBjb21wb25lbnQuIE9mdGVuLCBpdCBpcyBp" +
           "bmNyZWFzZWQgd2hlbiBlaXRoZXIgdGhlIFNvZnR3YXJlUmV2aXNpb24gYW5kIC8gb3IgdGhlIEhhcmR3" +
           "YXJlUmV2aXNpb24gb2YgdGhlIGNvbXBvbmVudCBpcyBpbmNyZWFzZWQuIEFzIGFuIGV4YW1wbGUsIGl0" +
           "IGNhbiBiZSB1c2VkIGluIEVSUCBzeXN0ZW1zIHRvZ2V0aGVyIHdpdGggdGhlIFByb2R1Y3RDb2RlLgAu" +
           "AER1AAAAAAz/////AQH/////AAAAABVgiQoCAAAAAQAKAAAATGVhZFNldEVuZAEBdgAALwA/dgAAAAAM" +
           "/////wEB/////wAAAAAVYIkKAgAAAAEACwAAAEhvdXNpbmdOYW1lAQF3AAAvAD93AAAAAAz/////AQH/" +
           "////AAAAABVgiQoCAAAAAQAMAAAAQ2F2aXR5TnVtYmVyAQF4AAAvAD94AAAAAAz/////AQH/////AAAA" +
           "AARggAoBAAAAAQANAAAASGFybmVzc0Zvcm1lcgEBeQAALwEBGQB5AAAA/////wQAAAAEYIAKAQAAAAEA" +
           "DgAAAElkZW50aWZpY2F0aW9uAQF6AAAvAQPtA3oAAAD/////AwAAADVgiQoCAAAAAgAMAAAATWFudWZh" +
           "Y3R1cmVyAQGBAAMAAAAASgAAAEEgaHVtYW4tcmVhZGFibGUsIGxvY2FsaXplZCBuYW1lIG9mIHRoZSBt" +
           "YW51ZmFjdHVyZXIgb2YgdGhlIE1hY2hpbmVyeUl0ZW0uAC4ARIEAAAAAFf////8BAf////8AAAAANWCJ" +
           "CgIAAAACAAwAAABTZXJpYWxOdW1iZXIBAYcAAwAAAAAXAQAAQSBzdHJpbmcgY29udGFpbmluZyBhIHVu" +
           "aXF1ZSBwcm9kdWN0aW9uIG51bWJlciBvZiB0aGUgbWFudWZhY3R1cmVyIG9mIHRoZSBNYWNoaW5lcnlJ" +
           "dGVtLiBUaGUgZ2xvYmFsIHVuaXF1ZW5lc3Mgb2YgdGhlIHNlcmlhbCBudW1iZXIgaXMgb25seSBnaXZl" +
           "biBpbiB0aGUgY29udGV4dCBvZiB0aGUgbWFudWZhY3R1cmVyLCBhbmQgcG90ZW50aWFsbHkgdGhlIG1v" +
           "ZGVsLiBUaGUgdmFsdWUgc2hhbGwgbm90IGNoYW5nZSBkdXJpbmcgdGhlIGxpZmUtY3ljbGUgb2YgdGhl" +
           "IE1hY2hpbmVyeUl0ZW0uAC4ARIcAAAAADP////8BAf////8AAAAANWCJCgIAAAABAA4AAABEZXZpY2VS" +
           "ZXZpc2lvbgEBigADAAAAAAgBAABBIHN0cmluZyByZXByZXNlbnRhdGlvbiBvZiB0aGUgb3ZlcmFsbCBy" +
           "ZXZpc2lvbiBsZXZlbCBvZiB0aGUgY29tcG9uZW50LiBPZnRlbiwgaXQgaXMgaW5jcmVhc2VkIHdoZW4g" +
           "ZWl0aGVyIHRoZSBTb2Z0d2FyZVJldmlzaW9uIGFuZCAvIG9yIHRoZSBIYXJkd2FyZVJldmlzaW9uIG9m" +
           "IHRoZSBjb21wb25lbnQgaXMgaW5jcmVhc2VkLiBBcyBhbiBleGFtcGxlLCBpdCBjYW4gYmUgdXNlZCBp" +
           "biBFUlAgc3lzdGVtcyB0b2dldGhlciB3aXRoIHRoZSBQcm9kdWN0Q29kZS4ALgBEigAAAAAM/////wEB" +
           "/////wAAAAAVYIkKAgAAAAEACAAAAEdyaXBwZXIxAQGLAAAvAD+LAAAAAAz/////AQH/////AAAAABVg" +
           "iQoCAAAAAQAIAAAAR3JpcHBlcjIBAYwAAC8AP4wAAAAADP////8BAf////8AAAAAFWCJCgIAAAABAAgA" +
           "AABHcmlwcGVyMwEBjQAALwA/jQAAAAAM/////wEB/////wAAAAAEYIAKAQAAAAEADgAAAElkZW50aWZp" +
           "Y2F0aW9uAQGOAAAvAQP0A44AAAADAAAAAC8BAQErAAEAw0QAAQPzAwEAw0QAAQPyAw8AAAA1YKkKAgAA" +
           "AAEABwAAAEFzc2V0SWQBAZAAAwAAAAAwAQAAVG8gYmUgdXNlZCBieSBlbmQgdXNlcnMgdG8gc3RvcmUg" +
           "YSB1bmlxdWUgaWRlbnRpZmljYXRpb24gaW4gdGhlIGNvbnRleHQgb2YgdGhlaXIgb3ZlcmFsbCBhcHBs" +
           "aWNhdGlvbi4gU2VydmVycyBzaGFsbCBzdXBwb3J0IGF0IGxlYXN0IDQwIFVuaWNvZGUgY2hhcmFjdGVy" +
           "cyBmb3IgdGhlIGNsaWVudHMgd3JpdGluZyB0aGlzIHZhbHVlLCB0aGlzIG1lYW5zIGNsaWVudHMgY2Fu" +
           "IGV4cGVjdCB0byBiZSBhYmxlIHRvIHdyaXRlIHN0cmluZ3Mgd2l0aCBhIGxlbmd0aCBvZiA0MCBVbmlj" +
           "b2RlIGNoYXJhY3RlcnMgaW50byB0aGF0IGZpZWxkLgAuAESQAAAADAAAAAAADP////8DA/////8AAAAA" +
           "NWCpCgIAAAABAA0AAABDb21wb25lbnROYW1lAQGRAAMAAAAAegEAAFRvIGJlIHVzZWQgYnkgZW5kIHVz" +
           "ZXJzIHRvIHN0b3JlIGEgaHVtYW4tcmVhZGFibGUgbG9jYWxpemVkIHRleHQgZm9yIHRoZSBNYWNoaW5l" +
           "cnlJdGVtLiBUaGUgbWluaW11bSBudW1iZXIgb2YgbG9jYWxlcyBzdXBwb3J0ZWQgZm9yIHRoaXMgcHJv" +
           "cGVydHkgc2hhbGwgYmUgdHdvLiBTZXJ2ZXJzIHNoYWxsIHN1cHBvcnQgYXQgbGVhc3QgNDAgVW5pY29k" +
           "ZSBjaGFyYWN0ZXJzIGZvciB0aGUgY2xpZW50cyB3cml0aW5nIHRoZSB0ZXh0IHBhcnQgb2YgZWFjaCBs" +
           "b2NhbGUsIHRoaXMgbWVhbnMgY2xpZW50cyBjYW4gZXhwZWN0IHRvIGJlIGFibGUgdG8gd3JpdGUgdGV4" +
           "dHMgd2l0aCBhIGxlbmd0aCBvZiA0MCBVbmljb2RlIGNoYXJhY3RlcnMgaW50byB0aGF0IGZpZWxkLgAu" +
           "AESRAAAAFQAAFf////8DA/////8AAAAANWCJCgIAAAABAAsAAABEZXZpY2VDbGFzcwEBkgADAAAAAEgA" +
           "AABJbmRpY2F0ZXMgaW4gd2hpY2ggZG9tYWluIG9yIGZvciB3aGF0IHB1cnBvc2UgdGhlIE1hY2hpbmVy" +
           "eUl0ZW0gaXMgdXNlZC4ALgBEkgAAAAAM/////wEB/////wAAAAA1YIkKAgAAAAEAEAAAAEhhcmR3YXJl" +
           "UmV2aXNpb24BAZMAAwAAAAAkAQAAQSBzdHJpbmcgcmVwcmVzZW50YXRpb24gb2YgdGhlIHJldmlzaW9u" +
           "IGxldmVsIG9mIHRoZSBoYXJkd2FyZSBvZiBhIE1hY2hpbmVyeUl0ZW0uIEhhcmR3YXJlIGlzIHBoeXNp" +
           "Y2FsIGVxdWlwbWVudCwgYXMgb3Bwb3NlZCB0byBwcm9ncmFtcywgcHJvY2VkdXJlcywgcnVsZXMgYW5k" +
           "IGFzc29jaWF0ZWQgZG9jdW1lbnRhdGlvbi4gTWFueSBtYWNoaW5lcyB3aWxsIG5vdCBwcm92aWRlIHN1" +
           "Y2ggaW5mb3JtYXRpb24gZHVlIHRvIHRoZSBtb2R1bGFyIGFuZCBjb25maWd1cmFibGUgbmF0dXJlIG9m" +
           "IHRoZSBtYWNoaW5lLgAuAESTAAAAAAz/////AQH/////AAAAADVgiQoCAAAAAQAUAAAASW5pdGlhbE9w" +
           "ZXJhdGlvbkRhdGUBAZQAAwAAAABpAAAAVGhlIGRhdGUsIHdoZW4gdGhlIE1hY2hpbmVyeUl0ZW0gd2Fz" +
           "IHN3aXRjaGVkIG9uIHRoZSBmaXJzdCB0aW1lIGFmdGVyIGl0IGhhcyBsZWZ0IHRoZSBtYW51ZmFjdHVy" +
           "ZXIgcGxhbnQuAC4ARJQAAAAADf////8BAf////8AAAAANWCJCgIAAAACAAwAAABNYW51ZmFjdHVyZXIB" +
           "AZUAAwAAAABKAAAAQSBodW1hbi1yZWFkYWJsZSwgbG9jYWxpemVkIG5hbWUgb2YgdGhlIG1hbnVmYWN0" +
           "dXJlciBvZiB0aGUgTWFjaGluZXJ5SXRlbS4ALgBElQAAAAAV/////wEB/////wAAAAA1YIkKAgAAAAEA" +
           "DwAAAE1hbnVmYWN0dXJlclVyaQEBlgADAAAAAEYAAABBIGdsb2JhbGx5IHVuaXF1ZSBpZGVudGlmaWVy" +
           "IG9mIHRoZSBtYW51ZmFjdHVyZXIgb2YgdGhlIE1hY2hpbmVyeUl0ZW0uAC4ARJYAAAAADP////8BAf//" +
           "//8AAAAANWCJCgIAAAABAAUAAABNb2RlbAEBlwADAAAAAEMAAABBIGh1bWFuLXJlYWRhYmxlLCBsb2Nh" +
           "bGl6ZWQgbmFtZSBvZiB0aGUgbW9kZWwgb2YgdGhlIE1hY2hpbmVyeUl0ZW0uAC4ARJcAAAAAFf////8B" +
           "Af////8AAAAANWCJCgIAAAABABMAAABNb250aE9mQ29uc3RydWN0aW9uAQGYAAMAAAAArQAAAFRoZSBt" +
           "b250aCBpbiB3aGljaCB0aGUgbWFudWZhY3R1cmluZyBwcm9jZXNzIG9mIHRoZSBNYWNoaW5lcnlJdGVt" +
           "IGhhcyBiZWVuIGNvbXBsZXRlZC4gSXQgc2hhbGwgYmUgYSBudW1iZXIgYmV0d2VlbiAxIGFuZCAxMiwg" +
           "cmVwcmVzZW50aW5nIHRoZSBtb250aCBmcm9tIEphbnVhcnkgdG8gRGVjZW1iZXIuAC4ARJgAAAAAA///" +
           "//8BAf////8AAAAANWCJCgIAAAABAAsAAABQcm9kdWN0Q29kZQEBmQADAAAAAPsAAABBIG1hY2hpbmUt" +
           "cmVhZGFibGUgc3RyaW5nIG9mIHRoZSBtb2RlbCBvZiB0aGUgTWFjaGluZXJ5SXRlbSwgdGhhdCBtaWdo" +
           "dCBpbmNsdWRlIG9wdGlvbnMgbGlrZSB0aGUgaGFyZHdhcmUgY29uZmlndXJhdGlvbiBvZiB0aGUgbW9k" +
           "ZWwuIFRoaXMgaW5mb3JtYXRpb24gbWlnaHQgYmUgcHJvdmlkZWQgYnkgdGhlIEVSUCBzeXN0ZW0gb2Yg" +
           "dGhlIHZlbmRvci4gRm9yIGV4YW1wbGUsIGl0IGNhbiBiZSB1c2VkIGFzIG9yZGVyIGluZm9ybWF0aW9u" +
           "LgAuAESZAAAAAAz/////AQH/////AAAAADVgiQoCAAAAAgASAAAAUHJvZHVjdEluc3RhbmNlVXJpAQGa" +
           "AAMAAAAAUQAAAEEgZ2xvYmFsbHkgdW5pcXVlIHJlc291cmNlIGlkZW50aWZpZXIgcHJvdmlkZWQgYnkg" +
           "dGhlIG1hbnVmYWN0dXJlciBvZiB0aGUgbWFjaGluZQAuAESaAAAAAAz/////AQH/////AAAAADVgiQoC" +
           "AAAAAgAMAAAAU2VyaWFsTnVtYmVyAQGbAAMAAAAAFwEAAEEgc3RyaW5nIGNvbnRhaW5pbmcgYSB1bmlx" +
           "dWUgcHJvZHVjdGlvbiBudW1iZXIgb2YgdGhlIG1hbnVmYWN0dXJlciBvZiB0aGUgTWFjaGluZXJ5SXRl" +
           "bS4gVGhlIGdsb2JhbCB1bmlxdWVuZXNzIG9mIHRoZSBzZXJpYWwgbnVtYmVyIGlzIG9ubHkgZ2l2ZW4g" +
           "aW4gdGhlIGNvbnRleHQgb2YgdGhlIG1hbnVmYWN0dXJlciwgYW5kIHBvdGVudGlhbGx5IHRoZSBtb2Rl" +
           "bC4gVGhlIHZhbHVlIHNoYWxsIG5vdCBjaGFuZ2UgZHVyaW5nIHRoZSBsaWZlLWN5Y2xlIG9mIHRoZSBN" +
           "YWNoaW5lcnlJdGVtLgAuAESbAAAAAAz/////AQH/////AAAAADVgiQoCAAAAAQAQAAAAU29mdHdhcmVS" +
           "ZXZpc2lvbgEBnAADAAAAANABAABBIHN0cmluZyByZXByZXNlbnRhdGlvbiBvZiB0aGUgcmV2aXNpb24g" +
           "bGV2ZWwgb2YgYSBNYWNoaW5lcnlJdGVtLiBJbiBtb3N0IGNhc2VzLCBNYWNoaW5lcnlJdGVtcyBjb25z" +
           "aXN0IG9mIHNldmVyYWwgc29mdHdhcmUgY29tcG9uZW50cy4gSW4gdGhhdCBjYXNlLCBpbmZvcm1hdGlv" +
           "biBhYm91dCB0aGUgc29mdHdhcmUgY29tcG9uZW50cyBtaWdodCBiZSBwcm92aWRlZCBhcyBhZGRpdGlv" +
           "bmFsIGluZm9ybWF0aW9uIGluIHRoZSBhZGRyZXNzIHNwYWNlLCBpbmNsdWRpbmcgaW5kaXZpZHVhbCBy" +
           "ZXZpc2lvbiBpbmZvcm1hdGlvbi4gSW4gdGhhdCBjYXNlLCB0aGlzIHByb3BlcnR5IGlzIGVpdGhlciBu" +
           "b3QgcHJvdmlkZWQgb3IgcHJvdmlkZXMgYW4gb3ZlcmFsbCBzb2Z0d2FyZSByZXZpc2lvbiBsZXZlbC4g" +
           "VGhlIHZhbHVlIG1pZ2h0IGNoYW5nZSBkdXJpbmcgdGhlIGxpZmUtY3ljbGUgb2YgYSBNYWNoaW5lcnlJ" +
           "dGVtLgAuAEScAAAAAAz/////AQH/////AAAAADVgiQoCAAAAAQASAAAAWWVhck9mQ29uc3RydWN0aW9u" +
           "AQGdAAMAAAAAxAAAAFRoZSB5ZWFyIChHcmVnb3JpYW4gY2FsZW5kYXIpIGluIHdoaWNoIHRoZSBtYW51" +
           "ZmFjdHVyaW5nIHByb2Nlc3Mgb2YgdGhlIE1hY2hpbmVyeUl0ZW0gaGFzIGJlZW4gY29tcGxldGVkLiBJ" +
           "dCBzaGFsbCBiZSBhIGZvdXItZGlnaXQgbnVtYmVyIGFuZCBuZXZlciBjaGFuZ2UgZHVyaW5nIHRoZSBs" +
           "aWZlLWN5Y2xlIG9mIGEgTWFjaGluZXJ5SXRlbS4ALgBEnQAAAAAF/////wEB/////wAAAAA1YIkKAgAA" +
           "AAEACAAAAExvY2F0aW9uAQGeAAMAAAAALQEAAFRvIGJlIHVzZWQgYnkgZW5kIHVzZXJzIHRvIHN0b3Jl" +
           "IHRoZSBsb2NhdGlvbiBvZiB0aGUgbWFjaGluZSBpbiBhIHNjaGVtZSBzcGVjaWZpYyB0byB0aGUgZW5k" +
           "IHVzZXIuIFNlcnZlcnMgc2hhbGwgc3VwcG9ydCBhdCBsZWFzdCA2MCBVbmljb2RlIGNoYXJhY3RlcnMg" +
           "Zm9yIHRoZSBjbGllbnRzIHdyaXRpbmcgdGhpcyB2YWx1ZSwgdGhpcyBtZWFucyBjbGllbnRzIGNhbiBl" +
           "eHBlY3QgdG8gYmUgYWJsZSB0byB3cml0ZSBzdHJpbmdzIHdpdGggYSBsZW5ndGggb2YgNjAgVW5pY29k" +
           "ZSBjaGFyYWN0ZXJzIGludG8gdGhhdCBmaWVsZC4ALgBEngAAAAAM/////wMD/////wAAAAAEYIAKAQAA" +
           "AAEAEgAAAE1hY2hpbmVyeUl0ZW1TdGF0ZQEBnwAALwED6gOfAAAA/////wEAAAAVYIkKAgAAAAAADAAA" +
           "AEN1cnJlbnRTdGF0ZQEBoAAALwEAyAqgAAAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQB" +
           "AaEAAC4ARKEAAAAAEf////8BAf////8AAAAABGCACgEAAAABABYAAABNYWNoaW5lcnlPcGVyYXRpb25N" +
           "b2RlAQGtAAAvAQPwA60AAAD/////AQAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQGuAAAvAQDI" +
           "Cq4AAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEBrwAALgBErwAAAAAR/////wEB////" +
           "/wAAAAAEYYIKBAAAAAEABQAAAFN0YXJ0AQG7AAAvAQG7ALsAAAABAf////8CAAAAF2CpCgIAAAAAAA4A" +
           "AABJbnB1dEFyZ3VtZW50cwEBvAAALgBEvAAAAJYCAAAAAQAqAQFAAAAACQAAAEFydGljbGVJRAAM////" +
           "/wAAAAADAAAAACAAAABUaGUgaWQgb2YgdGhlIGFydGljbGUgdG8gcHJvZHVjZQEAKgEBNgAAAAUAAABJ" +
           "dGVtcwAG/////wAAAAADAAAAABoAAABOdW1iZXIgb2YgaXRlbXMgdG8gcHJvZHVjZQEAKAEBAAAAAQAA" +
           "AAIAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAb0AAC4ARL0AAACWAQAA" +
           "AAEAKgEBNwAAAAYAAABSZXN1bHQABv////8AAAAAAwAAAAAaAAAATmVnYXRpdmUgbnVtYmVyIGFyZSBl" +
           "cnJvcnMBACgBAQAAAAEAAAABAAAAAQH/////AAAAAARhggoEAAAAAQAEAAAAU3RvcAEBvgAALwEBvgC+" +
           "AAAAAQH/////AQAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQG/AAAuAES/AAAAlgEAAAAB" +
           "ACoBATcAAAAGAAAAUmVzdWx0AAb/////AAAAAAMAAAAAGgAAAE5lZ2F0aXZlIG51bWJlciBhcmUgZXJy" +
           "b3JzAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAAEYYIKBAAAAAEABwAAAEFkZFBhcnQBAcAAAC8BAcAA" +
           "wAAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQHBAAAuAETBAAAAlgEAAAAB" +
           "ACoBASoAAAAEAAAAUGFydAAM/////wAAAAADAAAAAA8AAABBIG1hdGVyaWFsIHR5cGUBACgBAQAAAAEA" +
           "AAABAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQHCAAAuAETCAAAAlgEA" +
           "AAABACoBATcAAAAGAAAAUmVzdWx0AAb/////AAAAAAMAAAAAGgAAAE5lZ2F0aXZlIG51bWJlciBhcmUg" +
           "ZXJyb3JzAQAoAQEAAAABAAAAAQAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public FolderState MachineBuildingBlocks
        {
            get
            {
                return m_machineBuildingBlocks;
            }

            set
            {
                if (!Object.ReferenceEquals(m_machineBuildingBlocks, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_machineBuildingBlocks = value;
            }
        }

        /// <remarks />
        public StartMethodState Start
        {
            get
            {
                return m_startMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_startMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startMethod = value;
            }
        }

        /// <remarks />
        public StopMethodState Stop
        {
            get
            {
                return m_stopMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_stopMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_stopMethod = value;
            }
        }

        /// <remarks />
        public AddPartMethodState AddPart
        {
            get
            {
                return m_addPartMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_addPartMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_addPartMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <remarks />
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_machineBuildingBlocks != null)
            {
                children.Add(m_machineBuildingBlocks);
            }

            if (m_startMethod != null)
            {
                children.Add(m_startMethod);
            }

            if (m_stopMethod != null)
            {
                children.Add(m_stopMethod);
            }

            if (m_addPartMethod != null)
            {
                children.Add(m_addPartMethod);
            }

            base.GetChildren(context, children);
        }
            
        /// <remarks />
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case HarnessMachine.BrowseNames.MachineBuildingBlocks:
                {
                    if (createOrReplace)
                    {
                        if (MachineBuildingBlocks == null)
                        {
                            if (replacement == null)
                            {
                                MachineBuildingBlocks = new FolderState(this);
                            }
                            else
                            {
                                MachineBuildingBlocks = (FolderState)replacement;
                            }
                        }
                    }

                    instance = MachineBuildingBlocks;
                    break;
                }

                case HarnessMachine.BrowseNames.Start:
                {
                    if (createOrReplace)
                    {
                        if (Start == null)
                        {
                            if (replacement == null)
                            {
                                Start = new StartMethodState(this);
                            }
                            else
                            {
                                Start = (StartMethodState)replacement;
                            }
                        }
                    }

                    instance = Start;
                    break;
                }

                case HarnessMachine.BrowseNames.Stop:
                {
                    if (createOrReplace)
                    {
                        if (Stop == null)
                        {
                            if (replacement == null)
                            {
                                Stop = new StopMethodState(this);
                            }
                            else
                            {
                                Stop = (StopMethodState)replacement;
                            }
                        }
                    }

                    instance = Stop;
                    break;
                }

                case HarnessMachine.BrowseNames.AddPart:
                {
                    if (createOrReplace)
                    {
                        if (AddPart == null)
                        {
                            if (replacement == null)
                            {
                                AddPart = new AddPartMethodState(this);
                            }
                            else
                            {
                                AddPart = (AddPartMethodState)replacement;
                            }
                        }
                    }

                    instance = AddPart;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private FolderState m_machineBuildingBlocks;
        private StartMethodState m_startMethod;
        private StopMethodState m_stopMethod;
        private AddPartMethodState m_addPartMethod;
        #endregion
    }
    #endif
    #endregion
}
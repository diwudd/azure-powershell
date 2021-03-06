// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class InvokeAzureComputeMethodCmdlet : ComputeAutomationBaseCmdlet
    {
        protected object CreateVirtualMachineScaleSetVMListDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pVirtualMachineScaleSetName = new RuntimeDefinedParameter();
            pVirtualMachineScaleSetName.Name = "VirtualMachineScaleSetName";
            pVirtualMachineScaleSetName.ParameterType = typeof(string);
            pVirtualMachineScaleSetName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true
            });
            pVirtualMachineScaleSetName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("VirtualMachineScaleSetName", pVirtualMachineScaleSetName);

            var pSelect = new RuntimeDefinedParameter();
            pSelect.Name = "Select";
            pSelect.ParameterType = typeof(string);
            pSelect.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = false
            });
            pSelect.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("Select", pSelect);

            var pArgumentList = new RuntimeDefinedParameter();
            pArgumentList.Name = "ArgumentList";
            pArgumentList.ParameterType = typeof(object[]);
            pArgumentList.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByStaticParameters",
                Position = 4,
                Mandatory = true
            });
            pArgumentList.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ArgumentList", pArgumentList);

            return dynamicParameters;
        }

        protected void ExecuteVirtualMachineScaleSetVMListMethod(object[] invokeMethodInputParameters)
        {
            string resourceGroupName = (string)ParseParameter(invokeMethodInputParameters[0]);
            string virtualMachineScaleSetName = (string)ParseParameter(invokeMethodInputParameters[1]);
            Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM> odataQuery = (Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM>)ParseParameter(invokeMethodInputParameters[2]);
            string select = (string)ParseParameter(invokeMethodInputParameters[3]);

            var result = VirtualMachineScaleSetVMsClient.List(resourceGroupName, virtualMachineScaleSetName, odataQuery, select);
            var resultList = result.ToList();
            var nextPageLink = result.NextPageLink;
            while (!string.IsNullOrEmpty(nextPageLink))
            {
                var pageResult = VirtualMachineScaleSetVMsClient.ListNext(nextPageLink);
                foreach (var pageItem in pageResult)
                {
                    resultList.Add(pageItem);
                }
                nextPageLink = pageResult.NextPageLink;
            }
            WriteObject(resultList, true);
        }
    }

    public partial class NewAzureComputeArgumentListCmdlet : ComputeAutomationBaseCmdlet
    {
        protected PSArgument[] CreateVirtualMachineScaleSetVMListParameters()
        {
            string resourceGroupName = string.Empty;
            string virtualMachineScaleSetName = string.Empty;
            Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM> odataQuery = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM>();
            string select = string.Empty;

            return ConvertFromObjectsToArguments(
                 new string[] { "ResourceGroupName", "VirtualMachineScaleSetName", "OdataQuery", "Select" },
                 new object[] { resourceGroupName, virtualMachineScaleSetName, odataQuery, select });
        }
    }
}

﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PreviewCmdletInfo
{
    public class NewAzureReservedIPCmdletInfo : CmdletsInfo
    {
        public NewAzureReservedIPCmdletInfo(string name, string aff, string label, string svc, string dep)
        {
            this.cmdletName = Utilities.NewAzureReservedIPCmdletName;

            this.cmdletParams.Add(new CmdletParam("ReservedIPName", name));
            this.cmdletParams.Add(new CmdletParam("AffinityGroup", aff));

            if (!string.IsNullOrEmpty(label))
            {
                this.cmdletParams.Add(new CmdletParam("Label", label));
            }
            if (!string.IsNullOrEmpty(svc))
            {
                this.cmdletParams.Add(new CmdletParam("ServiceName", svc));
            }
            if (!string.IsNullOrEmpty(dep))
            {
                this.cmdletParams.Add(new CmdletParam("DeploymentName", dep));
            }
        }

        public NewAzureReservedIPCmdletInfo(string name, string location, string label)
        {
            this.cmdletName = Utilities.NewAzureReservedIPCmdletName;

            this.cmdletParams.Add(new CmdletParam("ReservedIPName", name));
            this.cmdletParams.Add(new CmdletParam("Location", location));

            if (!string.IsNullOrEmpty(label))
            {
                this.cmdletParams.Add(new CmdletParam("Label", label));
            }
        }
    }
}

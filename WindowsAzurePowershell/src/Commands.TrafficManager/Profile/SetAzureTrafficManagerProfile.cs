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

namespace Microsoft.WindowsAzure.Commands.TrafficManager.Profile
{
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Management.TrafficManager.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.TrafficManager;
    using Microsoft.WindowsAzure.Commands.Utilities.TrafficManager.Models;

    [Cmdlet(VerbsCommon.Set, "AzureTrafficManagerProfile"), OutputType(typeof(IProfileWithDefinition))]
    public class SetAzureTrafficManagerProfile : TrafficManagerConfigurationBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateSet("Performance", "Failover", "RoundRobin", IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancingMethod { get; set; }

        [Parameter(Mandatory = false)]
        public System.Int32? MonitorPort { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string MonitorProtocol { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string MonitorRelativePath { get; set; }

        [Parameter(Mandatory = false)]
        public System.Int32? Ttl { get; set; }

        public override void ExecuteCmdlet()
        {
            ProfileWithDefinition profile = TrafficManagerProfile.GetInstance();

            DefinitionCreateParameters updatedDefinitionAsParam =
                TrafficManagerClient.InstantiateTrafficManagerDefinition(
                LoadBalancingMethod ?? profile.LoadBalancingMethod.ToString(),
                MonitorPort.HasValue ? MonitorPort.Value : profile.MonitorPort,
                MonitorProtocol ?? profile.MonitorProtocol.ToString(),
                MonitorRelativePath ?? profile.MonitorRelativePath,
                Ttl.HasValue ? Ttl.Value : profile.TimeToLiveInSeconds);

            ProfileWithDefinition newDefinition =
                TrafficManagerClient.AssignDefinitionToProfile(Name, updatedDefinitionAsParam);

            WriteObject(newDefinition);
        }
    }
}

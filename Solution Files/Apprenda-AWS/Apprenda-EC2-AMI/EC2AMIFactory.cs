﻿using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Apprenda.SaaSGrid.Addons.AWS.EC2
{
    internal class Ec2AmiFactory
    {
        public static Ec2Response StartServer(DeveloperOptions developerOptions)
        {
            try
            {
                var ec2Config = new AmazonEC2Config { AuthenticationRegion = developerOptions.RegionEndpont };

                var ec2Client = new AmazonEC2Client(
                    new BasicAWSCredentials(developerOptions.AccessKey, developerOptions.SecretAccessKey), ec2Config);

                var launchRequest = new RunInstancesRequest
                {
                    ImageId = developerOptions.AmiId,
                    InstanceType = developerOptions.InstanceType,
                    MinCount = 1,
                    MaxCount = 1,
                    KeyName = developerOptions.Ec2KeyPair,
                    SecurityGroupIds = new List<string> { developerOptions.SecurityGroupId }
                };
                var launchResponse = ec2Client.RunInstances(launchRequest);
                if(launchResponse.HttpStatusCode.Equals(HttpStatusCode.OK))
                {
                    while (true)
                    {
                        var instances = ec2Client.DescribeInstances();
                        if(instances.Reservations.Contains(x => x.Equals(developerOptions.)))
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Ec2Response StopServer(ConnectionInfo info)
        {
        }

        public Ec2Response TerminateServer(ConnectionInfo info)
        {
        }
    }
}
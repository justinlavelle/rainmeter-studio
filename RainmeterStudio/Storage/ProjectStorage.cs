﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using RainmeterStudio.Core.Model;

namespace RainmeterStudio.Storage
{
    public class ProjectStorage
    {
        public Project Load(string path)
        {
            // Open file
            var file = File.OpenText(path);

            // Deserialize file
            var serializer = new XmlSerializer(typeof(Project), new XmlRootAttribute("project"));
            Project project = serializer.Deserialize(file) as Project;
            if (project != null)
                project.Path = path;

            // Clean up
            file.Close();
            return project;
        }

        public void Save(string path, Project project)
        {
            // Open file
            var file = File.OpenWrite(path);

            // Serialize file
            var serializer = new XmlSerializer(typeof(Project), new XmlRootAttribute("project"));
            serializer.Serialize(file, project);

            // Clean up
            file.Close();
            project.Path = path;
        }
    }
}
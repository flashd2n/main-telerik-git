﻿using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Adding
{
    internal class AddStudentToSeasonCommand : ICommand
    {
        protected readonly IAcademyFactory factory;
        protected readonly IEngine engine;

        public AddStudentToSeasonCommand(IAcademyFactory factory, IEngine engine)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory cannot be null.");
            }

            if (engine == null)
            {
                throw new ArgumentNullException("Engine cannot be null.");
            }

            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var studentUsername = parameters[0];
            var seasonId = parameters[1];

            var student = this.engine.Students.Single(x => x.Username.ToLower() == studentUsername.ToLower());
            var season = this.engine.Seasons[int.Parse(seasonId)];

            if (season.Students.Any(x => x.Username.ToLower() == studentUsername.ToLower()))
            {
                throw new ArgumentException($"The Student {studentUsername} is already a part of Season {seasonId}!");
            }

            season.Students.Add(student);
            return $"Student {studentUsername} was added to Season {seasonId}.";
        }
    }
}

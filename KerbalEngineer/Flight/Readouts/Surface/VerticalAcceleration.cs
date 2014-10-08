﻿// 
//     Kerbal Engineer Redux
// 
//     Copyright (C) 2014 CYBUTEK
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 

#region Using Directives

using KerbalEngineer.Extensions;

#endregion

namespace KerbalEngineer.Flight.Readouts.Surface
{
    public class VerticalAcceleration : ReadoutModule
    {
        private double speed;
        private double acceleration;
        public VerticalAcceleration()
        {
            this.Name = "Vertical Acceleration";
            this.Category = ReadoutCategory.GetCategory("Surface");
            this.HelpString = "Shows the vessel's vertical acceleration up and down.";
            this.IsDefault = true;
        }

        public override void FixedUpdate()
        {
            this.acceleration = (FlightGlobals.ship_verticalSpeed - this.speed) / TimeWarp.fixedDeltaTime;
            this.speed = FlightGlobals.ship_verticalSpeed;
        }

        public override void Draw()
        {
            this.DrawLine(this.acceleration.ToAcceleration());
        }
    }
}
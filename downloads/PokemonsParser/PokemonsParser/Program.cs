using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;

/**
 * PokemonParser Program
 * Takes xml data extracted from various related webpages using native xml-parsing objects 
 * and transforms the data into relevant queries used to populate a given database with
 * detailed pokemon information. Program is split up into separate functions that parse the
 * neccessary elements from a given xml document (in the same directory) and "hook" them 
 * together using dictionary objects. Once the objects are "hooked up" they are then 
 * written to a sql file which can be executed in a sql environment to generate meaningful
 * data for testing and observation. Another function o this code that is not used is the
 * function to connect to a specfic database and pipe these recordd commands in without
 * the need for an intermediary file location. This function will be used later in the project.
 * Through the use of XML and sql files, this program fill up a database with sufficient
 * pokemon information.
 * 
 * */

namespace PokemonsParser
{
    class PokeParser
    {
        static void Main(string[] args)
        {
			//Set up initial pokemon dictionary
            pokemon = new Dictionary<string, string>();
            parse_moves();
            parse_natures();
            parse_abilities();
            parse_types();
            parse_pokemon();
            hookup_abilities();
            hookup_weaknesses();
            hookup_types();
            hookup_tms();
            hookup_moves();
            hookup_evolutions();
            hookup_natures();
        }

		//Reference dictionary objects for different attribute container objects
        static public Dictionary<string, string> pokemon;
        static public Dictionary<string, string> types;
        static public Dictionary<string, string> abilities;
        static public Dictionary<string, string> natures;
        static public Dictionary<string, string> moves;

		//Takes a string and switches it to an acronym
        static public string translateName(string val)
        {
            /*
             * HP, Attack, Defense, Speed, Height, Weight, SpecialDef, SpecialAtk
             */
            switch (val)
            {
                case "Hit Points": return "HP";
                case "Attack": return "Attack";
                case "Defense": return "Defense";
                case "Special Attack": return "SpecialAtk";
                case "Special Defense": return "SpecialDef";
                case "Speed": return "Speed";
                default: return "NoName";
            }
        }

        /// <summary>
        /// Checks to see if a particular field is supposed to be a string.
        /// </summary>
        static public bool isChar(string val)
        {
            switch (val)
            {
                case "Name":
                case "Height":
                case "Weight":
                case "Description":
                    return true;
                default: return false;
            }
        }

        /// <summary>
        /// Adds escape characters to a string for SQL compliance.
        /// </summary>
        /// <param name="val">String to be modified.</param>
        /// <returns>Modified string.</returns>
        static public string cleanString(string val)
        {
            string tVal = val;
            {
                int sLoc = tVal.IndexOf('\'', 0); // so we don't repeat
                while (sLoc != -1)
                {
                    tVal = tVal.Insert(sLoc, "\'");
                    sLoc = tVal.IndexOf('\'', sLoc + 2);
                }
            }
            return "\'" + tVal + "\'";
        }

        /// <summary>
        /// Converts a Dictionary object into an SQL INSERT statement.
        /// </summary>
        static void writeToFilePokemon(Dictionary<string, string> entry)
        {
            //Form the insert statement
            string sqlStat = "INSERT INTO Pokemon(";
            List<string> attributes = new List<string>();

			// Insert a key for every pokemon
            foreach (KeyValuePair<string, string> kvp in entry)
            {
                attributes.Add(kvp.Key);
            }

			// Forming Sql query to add the accumulated values
            sqlStat += "GUID,";
            sqlStat += string.Join(",", attributes.ToArray());
            sqlStat += ") VALUES(";
            string myGUID = System.Guid.NewGuid().ToString();
            pokemon[entry["Name"]] = myGUID;
            sqlStat += "\'" + myGUID + "\'";
            sqlStat += ",";

			// Populating ketvaluepair string with entries
            foreach (KeyValuePair<string, string> kvp in entry)
            {
                if (isChar(kvp.Key))
                {
                    sqlStat += cleanString(kvp.Value);
                }
                else
                {
                    sqlStat += kvp.Value;
                }                
                sqlStat += ",";
            }
            sqlStat = sqlStat.Remove(sqlStat.Length - 1);
            sqlStat += ");\n";

			// Write output to file
            using (StreamWriter output = new StreamWriter(".\\sql_pokemon.sql", true))
            {
                output.Write(sqlStat);
            }
        }

        /// <summary>
        /// Writes the Dictionary object given to the database.
        /// </summary>
        static void writeToDB(Dictionary<string, string> entry)
        {
			// Forming connection string URL
            string connString = "server=database-new.cse.tamu.edu;database=jdonais-pokemonproject;uid=jdonais;pwd=11Jordan18SQL;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // Create the query
                string sqlStat = "INSERT INTO Pokemon(";
                List<string> attributes = new List<string>();
                foreach (KeyValuePair<string, string> kvp in entry)
                {
                    attributes.Add(kvp.Key);
                }
                sqlStat += "GUID,";
                sqlStat += string.Join(",", attributes.ToArray());
                sqlStat += ") VALUES(@GUID,";

                // Add the parameter values...
                for (int i = 0; i < attributes.Count; i++)
                {
                    attributes[i] = "@" + attributes[i];
                }
                sqlStat += string.Join(",", attributes.ToArray());
                sqlStat += ");";

				//Forming sql command with a SqlDBType attributes
                SqlCommand com = new SqlCommand(sqlStat, conn);
                com.Parameters.Add("@GUID", System.Data.SqlDbType.Char, 128).Value = System.Guid.NewGuid();
                com.Parameters.Add("@NationalID", System.Data.SqlDbType.Int).Value = entry["NationalID"];
                com.Parameters.Add("@Name", System.Data.SqlDbType.Char, 128).Value = entry["Name"];
                com.Parameters.Add("@HP", System.Data.SqlDbType.Int).Value = entry["HP"];
                com.Parameters.Add("@Attack", System.Data.SqlDbType.Int).Value = entry["Attack"];
                com.Parameters.Add("@Defense", System.Data.SqlDbType.Int).Value = entry["Defense"];
                com.Parameters.Add("@Speed", System.Data.SqlDbType.Int).Value = entry["Speed"];
                com.Parameters.Add("@SpecialDef", System.Data.SqlDbType.Int).Value = entry["SpecialDef"];
                com.Parameters.Add("@SpecialAtk", System.Data.SqlDbType.Int).Value = entry["SpecialAtk"];
                com.Parameters.Add("@Height", System.Data.SqlDbType.Char, 36).Value = entry["Height"];
                com.Parameters.Add("@Weight", System.Data.SqlDbType.Char, 36).Value = entry["Weight"];
                com.Parameters.Add("@Description", System.Data.SqlDbType.Char, 255).Value = entry["Description"];

				//Attempt to execute query on setup connection
                try
                {
                    conn.Open();
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
        }

		// Gives a double for the first two letters of a given string
        static public double stringToDouble(string input)
        {
            string tVal = input.Substring(0, 1);
            if (tVal == Convert.ToChar(188).ToString()) return .25;
            else if (tVal == Convert.ToChar(189).ToString()) return .5;
            else if (tVal == Convert.ToChar(190).ToString()) return .75;

            return Convert.ToInt32(tVal);
        }

		// Attach natures table to the rest of the tables 
        static public void hookup_natures()
        {
            string sqlStat = "";

			//Populating given dictionaries
            foreach (KeyValuePair<string, string> kvp in pokemon)
            {
                foreach (KeyValuePair<string, string> nature in natures)
                {
                    sqlStat+= "INSERT INTO Nature (PokemonUID, NatureUID) VALUES (";
                    sqlStat += cleanString(kvp.Value) + ",";
                    sqlStat += cleanString(nature.Value);
                    sqlStat += ");\n";
                }
            }

			//Writing queries to sql file
            using (StreamWriter output = new StreamWriter(".\\sql_nature_link.sql", true))
            {
                output.Write(sqlStat);
            }
        }
  
		// Attach weaknesses table to the rest of the tables
        static public void hookup_weaknesses()
        {
            Dictionary<string, Dictionary<string, List<string>>> typeAdv = new Dictionary<string, Dictionary<string, List<string>>>();

            // Setup this Dictionary object...
            foreach (KeyValuePair<string, string> t in types)
            {
                typeAdv.Add(t.Key, new Dictionary<string, List<string>>());
                typeAdv[t.Key].Add("Weaknesses", new List<string>());
                typeAdv[t.Key].Add("Strengths", new List<string>());
            }
            string sqlStatWeak = "";
            string sqlStatStrong = "";

			// Parse xml file for information
            using (XmlReader reader = XmlReader.Create(".\\types.xml"))
            {
                while (reader.Read())
                { // Determine the nature we have...
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element):
                            {
                                switch (reader.Name)
                                {
                                    case "Type":
                                        {
                                            // Get the type name...
                                            string name = reader.GetAttribute(0);
                                            reader.Read();
                                            // Read until we hit the end tag...
                                            while (reader.Name != "Type" && reader.NodeType != XmlNodeType.EndElement)
                                            {
                                                while (reader.Name != "TypeAttack") reader.Read();
                                                reader.Read();
                                                string atkName = reader.Value;
                                                while (reader.Name != "Effect") reader.Read();
                                                reader.Read();
                                                double damageVal = stringToDouble(reader.Value);
                                                // Is this a weakness, or a strength?
                                                if (damageVal > 1.0)
                                                {
                                                    typeAdv[name]["Strengths"].Add(atkName);
                                                    typeAdv[atkName]["Weaknesses"].Add(name);
                                                }
                                                reader.Read(); reader.Read(); reader.Read();
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }
            // Build SQL statements here
            foreach (KeyValuePair<string, Dictionary<string, List<string>>> t in typeAdv)
            {
                // Handle strengths...
                foreach (string str in t.Value["Strengths"])
                {
                    sqlStatStrong += "INSERT INTO Strengths (PokemonUIDStrong, PokemonUIDWeak) VALUES (";
                    sqlStatStrong += cleanString(types[t.Key]) + ",";
                    sqlStatStrong += cleanString(types[str]);
                    sqlStatStrong += ");\n";
                }
                // Handle weaknesses...
                foreach (string str in t.Value["Weaknesses"])
                {
                    sqlStatWeak += "INSERT INTO Weaknesses (PokemonUIDWeak, PokemonUIDStrong) VALUES (";
                    sqlStatWeak += cleanString(types[t.Key]) + ",";
                    sqlStatWeak += cleanString(types[str]);
                    sqlStatWeak += ");\n";
                }
            }

			// Writing weaknesses to sql file
            using (StreamWriter output = new StreamWriter(".\\sql_weaknesses.sql", true))
            {
                output.Write(sqlStatWeak);
            }
			// Writing strengths to sql file
            using (StreamWriter output = new StreamWriter(".\\sql_stregths.sql", true))
            {
                output.Write(sqlStatStrong);
            }

            Console.WriteLine("Finished setting up weaknesses and strengths...");
        }

        /// <summary>
        /// Parses Pokemon evolutions and uses the pokemon Dictionary to connect keys.
        /// </summary>
        static public void hookup_evolutions()
        {
            string sqlStat = "";
            bool isDone = false;

			// Reading xml file for data
            using (XmlReader reader = XmlReader.Create(".\\pokemonListing.xml"))
            {
                while (reader.Read())
                { // Look for a Pokemon tag
                    if (isDone) break;
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element):
                            {
                                switch (reader.Name)
                                {
                                    case "Pokemon":
                                        {
                                            // Read until we hit the first ability tag
                                            string pokeName = reader.GetAttribute(0); // for lookup purposes
                                            if (pokeName == "Treecko") isDone = true;
                                            if (isDone) break;
                                            while (reader.Name != "EvolveInfo") reader.Read();
                                            reader.Read();
                                            // Read the evolutions!
                                            while (reader.Name != "EvolveInfo")
                                            {
                                                reader.Read();
                                                while (reader.Name != "EvolutionName" && reader.Name != "EvolveInfo") reader.Read();
                                                if (reader.NodeType == XmlNodeType.EndElement) break;
                                                reader.Read();
                                                string evName = reader.Value;
                                                while (reader.Name != "Method") reader.Read();
                                                reader.Read();
                                                string method = reader.Value;
                                                string level = "";
                                                if (method == "Leveling")
                                                {
                                                    while (reader.Name != "Level") reader.Read();
                                                    reader.Read();
                                                    level = reader.Value;
                                                }

                                                if (!pokemon.ContainsKey(evName))
                                                { // Evolution in another generation that we are not using
                                                    break;
                                                }

                                                // Not all evolutions involve a level
                                                if (level == "")
                                                {
                                                    sqlStat += "INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Method) VALUES(";
                                                    sqlStat += cleanString(pokemon[pokeName]) + ",";
                                                    sqlStat += cleanString(pokemon[evName]) + ",";
                                                    sqlStat += cleanString(method) + ");\n";
                                                }
                                                else
                                                {
                                                    sqlStat += "INSERT INTO Evolutions(PokemonUIDFrom, PokemonUIDTo, Level_, Method) VALUES(";
                                                    sqlStat += cleanString(pokemon[pokeName]) + ",";
                                                    sqlStat += cleanString(pokemon[evName]) + ",";
                                                    sqlStat += level + ",";
                                                    sqlStat += cleanString(method) + ");\n";
                                                }
                                                reader.Read();
                                                while (reader.NodeType != XmlNodeType.EndElement) reader.Read();
                                                reader.Read();
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }

			// Write evolution information to file
            using (StreamWriter output = new StreamWriter(".\\sql_evolution_link.sql", true))
            {
                output.Write(sqlStat);
            }

            Console.WriteLine("Finished linking evolutions...");
        }

        /// <summary>
        /// Parses the moves a Pokemon can learn and links those moves to the Pokemon.
        /// </summary>
        static public void hookup_moves()
        {
            string sqlStat = "";
            bool isDone = false;
            using (XmlReader reader = XmlReader.Create(".\\pokemonListing.xml"))
            {
                while (reader.Read())
                { // Look for a Pokemon tag
                    if (isDone) break;
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element):
                            {
                                switch (reader.Name)
                                {
                                    case "Pokemon":
                                        {
                                            // Read until we hit the first ability tag
                                            string pokeName = reader.GetAttribute(0); // for lookup purposes
                                            // This Pokemon is the start of the generation we do not consider
                                            if (pokeName == "Treecko") isDone = true;
                                            if (isDone) break;
                                            while (reader.Name != "MoveListing") reader.Read();
                                            if (reader.GetAttribute(0) != "II") break;
                                            // Read the moves!
                                            while (reader.Name != "MoveListing" || reader.GetAttribute(0) == "II")
                                            {
                                                reader.Read();
                                                while ((reader.NodeType != XmlNodeType.Element || reader.Name == "MoveItem") && reader.Name != "MoveListing") reader.Read();
                                                if (reader.NodeType == XmlNodeType.EndElement) break;
                                                reader.Read();
                                                if (reader.Value == "None")
                                                {
                                                    break;
                                                }
                                                string moveName = reader.Value;
                                                reader.Read();
                                                while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                                reader.Read();
                                                string level = reader.Value;
                                                sqlStat += "INSERT INTO MoveSet(PokemonUID, MoveUID, Level_) VALUES (";
                                                sqlStat += cleanString(pokemon[pokeName]) + ",";
                                                sqlStat += cleanString(moves[moveName]) + ",";
                                                sqlStat += level + ");\n";
                                                reader.Read();
                                                while (reader.NodeType != XmlNodeType.EndElement) reader.Read();
                                                reader.Read();
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }
            using (StreamWriter output = new StreamWriter(".\\sql_move_link.sql", true))
            {
                output.Write(sqlStat);
            }

            Console.WriteLine("Finished linking moves...");
        }

        /// <summary>
        /// Parses the TMs that a Pokemon can learn and links the two.
        /// </summary>
        static public void hookup_tms()
        {
            string sqlStat = "";
            bool isDone = false;

			// Reading from xml file
            using (XmlReader reader = XmlReader.Create(".\\pokemonListing.xml"))
            {
                while (reader.Read())
                { // Look for a Pokemon tag
                    if (isDone) break;
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element):
                            {
                                switch (reader.Name)
                                {
                                    case "Pokemon":
                                        {
                                            // Read until we hit the first ability tag
                                            string pokeName = reader.GetAttribute(0); // for lookup purposes
                                            if (pokeName == "Treecko") isDone = true;
                                            if (isDone) break;
                                            while (reader.Name != "TMListing") reader.Read();
                                            if (reader.GetAttribute(0) != "II") break;
                                            // Read the moves!
                                            while (reader.Name != "TMListing" || reader.GetAttribute(0) == "II")
                                            {
                                                reader.Read();
                                                if (reader.NodeType == XmlNodeType.EndElement) break;
                                                while (reader.NodeType != XmlNodeType.Element || reader.Name == "MoveItem") reader.Read();
                                                reader.Read();
                                                if (reader.Value == "None")
                                                {
                                                    break;
                                                }
                                                sqlStat += "INSERT INTO TMs(PokemonUID, MoveUID) VALUES (";
                                                sqlStat += cleanString(pokemon[pokeName]) + ",";
                                                sqlStat += cleanString(moves[reader.Value]) + ");\n";
                                                reader.Read();
                                                while (reader.NodeType != XmlNodeType.EndElement) reader.Read();
                                                reader.Read();
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }

			// Write result to sql file
            using (StreamWriter output = new StreamWriter(".\\sql_tm_link.sql", true))
            {
                output.Write(sqlStat);
            }

            Console.WriteLine("Finished linking TMs...");

        }

        /// <summary>
        /// Parses the types that a Pokemon is, and links the two.
        /// </summary>
        static public void hookup_types()
        {
            string sqlStat = "";
            bool isDone = false;
            using (XmlReader reader = XmlReader.Create(".\\pokemonListing.xml"))
            {
                while (reader.Read())
                { // Look for a Pokemon tag
                    if (isDone) break;
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element):
                            {
                                switch (reader.Name)
                                {
                                    case "Pokemon":
                                        {
                                            // Read until we hit the first ability tag
                                            string pokeName = reader.GetAttribute(0); // for lookup purposes
                                            if (pokeName == "Treecko") isDone = true;
                                            if (isDone) break;
                                            while (reader.Name != "Type") reader.Read();

                                            // Read the types!
                                            while (reader.Name != "Weaknesses")
                                            {
                                                reader.Read();
                                                if (reader.NodeType == XmlNodeType.EndElement) break;
                                                while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                                reader.Read();
                                                sqlStat += "INSERT INTO Type_(PokemonUID, TypeUID) VALUES (";
                                                sqlStat += cleanString(pokemon[pokeName]) + ",";
                                                sqlStat += cleanString(types[reader.Value]) + ");\n";
                                                reader.Read();
                                                while (reader.NodeType != XmlNodeType.EndElement) reader.Read();
                                                reader.Read();
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }
			// Write output to sql file
            using (StreamWriter output = new StreamWriter(".\\sql_type_link.sql", true))
            {
                output.Write(sqlStat);
            }

            Console.WriteLine("Finished linking types...");

        }

        /// <summary>
        /// Parses the abilities that a Pokemon can have and links the two.
        /// </summary>
        static public void hookup_abilities()
        {
            string sqlStat = "";
            bool isDone = false;

			// Read data from xml
            using (XmlReader reader = XmlReader.Create(".\\pokemonListing.xml"))
            {
                while (reader.Read())
                { // Look for a Pokemon tag
                    if (isDone) break;
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element):
                            {
                                switch (reader.Name)
                                {
                                    case "Pokemon":
                                        {
                                            // Read until we hit the first ability tag
                                            string pokeName = reader.GetAttribute(0); // for lookup purposes
                                            if (pokeName == "Treecko") isDone = true;
                                            if (isDone) break;
                                            while (reader.Name != "Ability") reader.Read();
                                            
                                            // Read the abilities!
                                            while (reader.Name != "EvolveInfo")
                                            {
                                                reader.Read();
                                                if (reader.NodeType == XmlNodeType.EndElement) break;
                                                while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                                reader.Read();
                                                sqlStat += "INSERT INTO Ability(PokemonUID, AbilityUID) VALUES (";
                                                sqlStat += cleanString(pokemon[pokeName]) + ",";
                                                sqlStat += cleanString(abilities[reader.Value]) + ");\n";
                                                reader.Read();
                                                while (reader.NodeType != XmlNodeType.EndElement) reader.Read();
                                                reader.Read();
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }
            using (StreamWriter output = new StreamWriter(".\\sql_ability_link.sql", true))
            {
                output.Write(sqlStat);
            }

            Console.WriteLine("Finished linking abilities...");

        }

        /// <summary>
        /// Parses the XML file for the moves and formats them for SQL insertion.
        /// </summary>
        static public void parse_moves()
        {
            moves = new Dictionary<string, string>();
            Dictionary<string, string> locMove = new Dictionary<string, string>();
            string sqlStat = "";
            using (XmlReader reader = XmlReader.Create(".\\moves.xml"))
            {
                while (reader.Read())
                { // Determine the move we have...
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element):
                            {
                                switch (reader.Name)
                                {
                                    case "Move":
                                        {
                                            // The move's name is in the attribute...
                                            locMove["Name"] = reader.GetAttribute(0);
                                            // Read thrice to get name...
                                            reader.Read();
                                            while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                            reader.Read();
                                            // This is a useless field for us... skip it
                                            reader.Read();
                                            while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                            reader.Read();
                                            // This should be the Type field
                                            locMove["Type_"] = reader.Value;
                                            reader.Read();
                                            while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                            reader.Read();
                                            // This should be the kind field
                                            locMove["Kind"] = reader.Value;
                                            reader.Read();
                                            while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                            reader.Read();
                                            // This should be the PP field
                                            locMove["PP"] = reader.Value;
                                            reader.Read();
                                            while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                            reader.Read();
                                            // This should be the Power field
                                            locMove["Power_"] = reader.Value;
                                            reader.Read();
                                            while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                            reader.Read();
                                            // This should be the Accuracy field
                                            locMove["Accuracy"] = reader.Value;
                                            locMove["GUID"] = System.Guid.NewGuid().ToString();

                                            moves[locMove["Name"]] = locMove["GUID"];
                                            sqlStat += "INSERT INTO Moves (GUID, Name, Type_, Kind, Power_, Accuracy, PP) VALUES(";
                                            sqlStat += "\'" + locMove["GUID"] + "\',";
                                            sqlStat += cleanString(locMove["Name"]) + ",";
                                            sqlStat += cleanString(locMove["Type_"]) + ",";
                                            sqlStat += cleanString(locMove["Kind"]) + ",";
                                            // Not all moves have an integer value for Power and Accuracy
                                            if (locMove["Power_"] == "Varies" || locMove["Power_"] == "None" || locMove["Power_"] == "K/O")
                                            {
                                                sqlStat += cleanString(locMove["Power_"]) + ",";
                                            }
                                            else
                                            {
                                                sqlStat += locMove["Power_"] + ",";
                                            }
                                            if (locMove["Accuracy"] == "Varies" || locMove["Accuracy"] == "None" || locMove["Accuracy"] == "K/O")
                                            {
                                                sqlStat += cleanString(locMove["Accuracy"]) + ",";
                                            }
                                            else
                                            {
                                                sqlStat += locMove["Accuracy"] + ",";
                                            }
                                            sqlStat += locMove["PP"];                                                
                                            sqlStat += ");\n";
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }

            using (StreamWriter output = new StreamWriter(".\\sql_moves.sql", true))
            {
                output.Write(sqlStat);
            }

            Console.WriteLine("Finished generating moves...");
        }
        
        /// <summary>
        /// Parses the XML file containing the natures and formats them for SQL insertion.
        /// </summary>
        static public void parse_natures()
        {
            natures = new Dictionary<string, string>();
            Dictionary<string, string> locNature = new Dictionary<string, string>();
            string sqlStat = "";
            using (XmlReader reader = XmlReader.Create(".\\natures2.xml"))
            {
                while (reader.Read())
                { // Determine the nature we have...
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element):
                            {
                                switch (reader.Name)
                                {
                                    case "Nature":
                                        {
                                            // Read thrice to get name...
                                            reader.Read(); reader.Read(); reader.Read();
                                            locNature["Name"] = reader.Value;
                                            locNature["GUID"] = System.Guid.NewGuid().ToString();
                                            // Read three more times...
                                            reader.Read();
                                            while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                            reader.Read();
                                            locNature["Effect"] = reader.Value;
                                            natures[locNature["Name"]] = locNature["GUID"];
                                            sqlStat += "INSERT INTO Natures (GUID, Name, Effect) VALUES(";
                                            sqlStat += "\'" + locNature["GUID"] + "\',";
                                            sqlStat += cleanString(locNature["Name"]) + ",";
                                            sqlStat += cleanString(locNature["Effect"]) + ");\n";
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }

            using (StreamWriter output = new StreamWriter(".\\sql_natures.sql", true))
            {
                output.Write(sqlStat);
            }

            Console.WriteLine("Finished generating natures...");
        }
        
        /// <summary>
        /// Parses the XML file for abilities, and formats them for SQL insertion.
        /// </summary>
        static public void parse_abilities()
        {
            abilities = new Dictionary<string, string>();
            Dictionary<string, string> locAbility = new Dictionary<string, string>();
            string sqlStat = "";
            using (XmlReader reader = XmlReader.Create(".\\abilities.xml"))
            {
                while (reader.Read())
                { // Determine the ability we have...
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element):
                            {
                                switch (reader.Name)
                                {
                                    case "Ability":
                                        {
                                            // Read thrice to get name...
                                            reader.Read(); reader.Read(); reader.Read();
                                            locAbility["Name"] = reader.Value;
                                            locAbility["GUID"] = System.Guid.NewGuid().ToString();
                                            // Read three more times...
                                            reader.Read();
                                            while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                            reader.Read();
                                            locAbility["Effect"] = reader.Value;
                                            abilities[locAbility["Name"]] = locAbility["GUID"];
                                            sqlStat += "INSERT INTO Abilities (GUID, Name, Effect) VALUES(";
                                            sqlStat += "\'" + locAbility["GUID"] + "\',";
                                            sqlStat += cleanString(locAbility["Name"]) + ",";
                                            sqlStat += cleanString(locAbility["Effect"]) + ");\n";
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }

            using (StreamWriter output = new StreamWriter(".\\sql_abilities.sql", true))
            {
                output.Write(sqlStat);
            }

            Console.WriteLine("Finished generating abilities...");
        }

        /// <summary>
        /// Get the unique types and assign them an id
        /// </summary>
        static public void parse_types()
        {
            types = new Dictionary<string, string>();
            using (XmlReader reader = XmlReader.Create(".\\pokemonListing.xml"))
            {
                while (reader.Read())
                { // Determine the type we have...
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element):
                            {
                                switch (reader.Name)
                                {
                                    case "Type":
                                        {
                                            reader.Read();
                                            if (!reader.Value.Contains(' '))
                                            {
                                                types[reader.Value] = "";
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }
            // We should have all the types now, generate ids for them
            for (int i = 0; i < types.Count; i++)
            {
                types[types.ElementAt(i).Key] = System.Guid.NewGuid().ToString();
            }


            string sqlStat = "";
            // For each one, write the insert statement...
            foreach (KeyValuePair<string, string> kvp in types)
            {
                sqlStat += "INSERT INTO Types(GUID, Name) VALUES(";
                sqlStat += "\'" + kvp.Value + "\'";
                sqlStat += ",\'" + kvp.Key + "\');\n";
            }

            using (StreamWriter output = new StreamWriter(".\\sql_types.sql", true))
            {
                output.Write(sqlStat);
            }

            Console.WriteLine("Finished generating types...");
        }

        /// <summary>
        /// Parses the XML file for Pokemon and formats them for SQL insertion.
        /// </summary>
        static public void parse_pokemon()
        {
            Dictionary<string, string> entry = new Dictionary<string, string>();
            bool writeOut = false;
            using (XmlReader reader = XmlReader.Create(".\\pokemonListing.xml"))
            {
                while (reader.Read())
                { // Determine the Pokemon we have...
                    writeOut = false;
                    switch (reader.NodeType)
                    {
                        case (XmlNodeType.Element): 
                        {
                            switch (reader.Name)
                            {
                                case "Pokemon":
                                    { // We need to get the name
                                        entry["Name"] = reader.GetAttribute(0);
                                        break;
                                    }
                                case "PokedexEntry":
                                    {
                                        if (reader.GetAttribute(0) == "National")
                                        {   // Check to see if we're done
                                            reader.Read();
                                            while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                            reader.Read();
                                            if (System.Convert.ToInt32(reader.Value) > 251) return;
                                            entry["NationalID"] = reader.Value;

                                        }
                                        break;
                                    }
                                case "PhysStats":
                                    {
                                        reader.Read();
                                        while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                        reader.Read();
                                        // This should be Height
                                        entry["Height"] = reader.Value;
                                        reader.Read();
                                        while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                        reader.Read();
                                        // This should be Weight
                                        entry["Weight"] = reader.Value;
                                        break;
                                    }
                                case "Stat":
                                    {
                                        reader.Read();
                                        while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                        reader.Read();
                                        // This should be the name
                                        string statName = reader.Value;
                                        reader.Read();
                                        while (reader.NodeType != XmlNodeType.Element) reader.Read();
                                        reader.Read();
                                        // This should be the value
                                        entry[translateName(statName)] = reader.Value;
                                        break;
                                    }
                                case "Description":
                                    {
                                        reader.Read();
                                        entry["Description"] = reader.Value;
                                        writeOut = true;
                                        break;
                                    }
                            }
                            break;
                        }
                    }
                    if (writeOut)
                    {
                        //writeToDB(entry);
                        writeToFilePokemon(entry);
                        entry.Clear();
                    }
                }
            }
        }
    }


}

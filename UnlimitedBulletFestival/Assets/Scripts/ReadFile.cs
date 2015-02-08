using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

public class ReadFile : MonoBehaviour {

	 public List<string> Load(string fileName)
	 {
	     // Handle any problems that might arise when reading the text
	         string line;
	         List<string> commands = new List<string>();
	         // Create a new StreamReader, tell it which file to read and what encoding the file
	         // was saved as
	         StreamReader theReader = new StreamReader("Assets/UBFScripts/" + fileName + ".ubf", Encoding.Default);

	         // Immediately clean up the reader after this block of code is done.
	         // You generally use the "using" statement for potentially memory-intensive objects
	         // instead of relying on garbage collection.
	         // (Do not confuse this with the using directive for namespace at the
	         // beginning of a class!)
	         using (theReader)
	         {
	             do
	             {
	                 line = theReader.ReadLine();
	                 if (line != null)
	                 {
	                 	commands.Add(line);
	                     // Debug.Log(line);
	                 }
	             }
	             while (line != null);

	             // Done reading, close the reader and return true to broadcast success
	             theReader.Close();

	             return commands;
             }
	     }
}

// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.5.34
// 

using Colyseus.Schema;

public class MyState : Schema {
	[Type(0, "boolean")]
	public bool gameStarted = false;

	[Type(1, "string")]
	public string firstPlayer = "";

	[Type(2, "string")]
	public string secondPlayer = "";

	[Type(3, "boolean")]
	public bool firstPlayersTurn = false;

	[Type(4, "array", "string")]
	public ArraySchema<string> field = new ArraySchema<string>();

	[Type(5, "string")]
	public string winner = "";
}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tree : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Node root = new Node("Root");
		root.children.Add(new Node("Node0"));
		root.children.Add(new Node("Node1"));
		root.children[0].children.Add(new Node("Node00"));
		root.children[0].children.Add(new Node("Node01"));
		root.children[0].children.Add(new Node("Node02"));
		root.children[0].children.Add(new Node("Node03"));
		root.children[0].children.Add(new Node("Node04"));
		root.children[0].children.Add(new Node("Node05"));
		root.children[0].children[1].children.Add(new Node("Node010"));
		root.children[0].children[2].children.Add(new Node("Node020"));
		root.children[0].children[2].children.Add(new Node("Node021"));
		root.children[1].children.Add(new Node("Node10"));
		root.children[1].children.Add(new Node("Node11"));
		root.children[1].children.Add(new Node("Node12"));
		root.children[1].children[2].children.Add(new Node("Node120"));
		root.children[1].children[2].children.Add(new Node("Node121"));
		root.children[1].children[2].children.Add(new Node("Node123"));
		root.children[1].children[2].children.Add(new Node("Node124"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void drawNode(Node node, float l, float r, float d, float dParent, float dParentMax)
	{
		if (node != Node.root)
			GUI.Box (new Rect( (int)(r + l)/2 - 5, (int)(100 + (dParent + 1) * 70), 10, 20 + (d - dParent - 1) * 70), "");
		GUI.Box (new Rect( (int)(l), (int)(120 + d * 70), r - l , 50), node.name);

		List<int> widths = new List<int>();
		int totalWidths = 0;
		foreach(Node child in node.children) {
			int w = Mathf.Max (1, child.findMaxWidth());
			widths.Add (w);
			totalWidths += w;
		}

		float pastLeft = l;
		int divider = 1;
		while ( ((totalWidths - 1)/divider + 1) * 70 + (divider - 1) * 10 > r - l) {
			divider++;
		}

		int dividerCounter = 0;
		for (int i = 0; i < node.children.Count; ++i) {
			node.children[i].name = (dParentMax + 1 + (dividerCounter % divider)).ToString() + " " +
									 d.ToString() + " " + (dParentMax + divider).ToString();
			if (dividerCounter % divider > 0) {
				drawNode (node.children[i], 
				          pastLeft - 45,  
				          pastLeft + widths[i] * (r - l - (divider - 1) * 10) / ((totalWidths - 1)/divider + 1), 
				          dParentMax + 1 + (dividerCounter % divider),
				          d,
				          dParentMax + divider);
				pastLeft += 45; 
			}
			else {
				drawNode (node.children[i], 
				          pastLeft,  
				          pastLeft + widths[i] * (r - l - (divider - 1) * 10) / ((totalWidths - 1)/divider + 1), 
				          dParentMax + 1,
				          d,
				          dParentMax + divider);
				pastLeft += widths[i] * (r - l - (divider - 1) * 10) / ((totalWidths - 1)/divider + 1); 
			}
			dividerCounter++;
		}
	}

	public void OnGUI() 
	{

		//drawNode (Node.root, 100, Screen.width - 100, 0, -1, 0);

	}
}

public class Node {
	public static Node root;

	public string name;
	public List<Node> children;
	public Node parent;

	public Node(string name) {
		if (Node.root == null)
			Node.root = this;

		this.name = name;
		children = new List<Node>();
		parent = null;
	}

	public int findMaxWidth() {
		List<Node> childList = new List<Node>();
		List<Node> childList2 = new List<Node>();
		int max = 0;
		childList.Add (this);

		while (childList.Count > 0) {
			for(int i = 0; i < childList.Count; ++i) {
				childList2.AddRange(childList[i].children);
			}
			max = Mathf.Max (max, childList2.Count);
			childList = childList2;
			childList2 = new List<Node>();
		}

		return max;
	}
}
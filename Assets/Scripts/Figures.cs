using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FColor {
    black,
    white
}
public abstract class Figure {
    private FColor color;
    
    // default constructor
    public Figure(){
    }

    // constructor you should use
    public Figure(FColor color){
        this.color = color;
    }

    public FColor getColor(){
        return this.color;
    }

    public void setColor(FColor color){
        this.color = color;
    }

    public abstract string getMoveSet();
    public abstract void move();
}

public class Pawn : Figure {
    private string moveSet;

    public Pawn(){}

    public Pawn(FColor color) : base(color) {
    }

    public override string getMoveSet(){
        return this.moveSet;
    }

    public override void move(){
        // TODO move Pawn 1 Field up or capture other figure diagonally
    }
}

public class Knight : Figure {
    private string moveSet;

    public Knight(){}

    public Knight(FColor color) : base(color) {
    }

    public override string getMoveSet(){
        return this.moveSet;
    }

    public override void move(){
        // TODO move Knight or capture other figure diagonally
    }
}

public class King : Figure {
    private string moveSet;

    public King(){}

    public King(FColor color) : base(color) {
    }

    public override string getMoveSet(){
        return this.moveSet;
    }

    public override void move(){
        // TODO move King or capture other figure diagonally
    }

    public bool isMate(){
        // TODO return if King is in Mate
        return false;
    }

    public bool isCheckMate(){
        // TODO return if King is CheckMate
        return false;
    }
}

public class Queen : Figure {
    private string moveSet;

    public Queen(){}

    public Queen(FColor color) : base(color) {
    }

    public override string getMoveSet(){
        return this.moveSet;
    }

    public override void move(){
        // TODO move Queen or capture other figure diagonally
    }
}

public class Rook : Figure {
    private string moveSet;

    public Rook(){}

    public Rook(FColor color) : base(color) {
    }

    public override string getMoveSet(){
        return this.moveSet;
    }

    public override void move(){
        // TODO move Rook or capture other figure diagonally
    }
}

public class Bishop : Figure {
    private string moveSet;

    public Bishop(){}

    public Bishop(FColor color) : base(color) {
    }

    public override string getMoveSet(){
        return this.moveSet;
    }

    public override void move(){
        // TODO move Bishop or capture other figure diagonally
    }
}

/* possible movements for each figure
Pawn:   standard -> move 1 tile forward (can move 2 to tiles when on base line)
        not standard -> can take figure diagonally forward

Rook:   standard -> can move unlimited in rows

Bishop: standard -> can move unlimited diagonally

Knight: standard -> can move 2 fields in one direction, then 1 left of right

King:   standard -> can move 1 field, each direction possible

Queen:  standard -> can move unlimited fields in each direction
*/
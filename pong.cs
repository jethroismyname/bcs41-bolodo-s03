using Godot;
using System;


public class pong : Node2D
{
    private Label playerScoreLabel;
    private Label playerScoreLabel2;

    private Ball ball;
    private Vector2 screenSize;
    private int playerScore = 0;
    private int playerScore2 = 0;
    
    public override void _Ready()
    {
        ball = GetNode<Ball>("Ball");
        screenSize = new Vector2(320, 191);


        playerScoreLabel = GetNode<Label>("PlayerScore");
        if (playerScoreLabel != null)
            playerScoreLabel.Text = "0";
        
        playerScoreLabel2 = GetNode<Label>("PlayerScore2");
        if (playerScoreLabel2 != null)
            playerScoreLabel2.Text = "0";
            
    }
    private void _on_RightWall_body_entered(Node2D body)
    {
        playerScore += 1;
        ball.Position = new Vector2(screenSize.x , screenSize.y );
        UpdateScoreLabels();
    }
    private void UpdateScoreLabels()
    {
        // Make sure playerScoreLabel is properly assigned in your scene.
        if (playerScoreLabel != null)
            playerScoreLabel.Text = playerScore.ToString();
        if (playerScoreLabel2 != null)
            playerScoreLabel2.Text = playerScore2.ToString();

    }
    private void _on_LeftWall_body_entered(Node2D body)
    {
        ball.Position = new Vector2(screenSize.x , screenSize.y );
        playerScore2 += 1;
        UpdateScoreLabels();
    }
    
}

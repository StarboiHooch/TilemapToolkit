using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class CustomRuleTile : RuleTile<RuleTile.TilingRule.Neighbor>
{
    //public class Neighbor : RuleTile.TilingRule.Neighbor
    //{
    //    public const int NotThis = 2;
    //    public const int This = 1;
    //}

    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        switch (neighbor)
        {
            case RuleTile.TilingRule.Neighbor.NotThis: return tile != this;
            case RuleTile.TilingRule.Neighbor.This: return tile == this;
        }
        return base.RuleMatch(neighbor, tile);
    }
}
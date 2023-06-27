using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class CustomRuleTile : RuleTile<CustomRuleTile.Neighbor>
{
    public class Neighbor : RuleTile.TilingRule.Neighbor
    {
        public const int Null = 2;
        public const int NotNull = 1;
    }

    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        switch (neighbor)
        {
            case Neighbor.Null: return tile == null;
            case Neighbor.NotNull: return tile != null;
        }
        return base.RuleMatch(neighbor, tile);
    }
}
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class PipeSiblings : RuleTile
{

    public enum SibingGroup
    {
        Pipes,
        HotPipes,
        ColdPipes
    }
    public SibingGroup sibingGroup;

    public override bool RuleMatch(int neighbor, TileBase other)
    {
        if (other is RuleOverrideTile)
            other = (other as RuleOverrideTile).m_InstanceTile;

        switch (neighbor)
        {
            case TilingRule.Neighbor.This:
                {
                    return other is PipeSiblings
                        && (other as PipeSiblings).sibingGroup == this.sibingGroup;
                }
            case TilingRule.Neighbor.NotThis:
                {
                    return !(other is PipeSiblings
                        && (other as PipeSiblings).sibingGroup == this.sibingGroup);
                }
        }

        return base.RuleMatch(neighbor, other);
    }
}
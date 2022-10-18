using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Specialized Version Of The Pool To Allow You To Pool Objects At A Application level
// TODO: This needs completing, its a very niche thing for application based pooling.
//       If Used In Levels It Would Need To Listen To The levels beign loaded and unloaded events
public class ApplicationLevelAccessiblePool : ApplicationSingleton<ApplicationLevelAccessiblePool>
{}

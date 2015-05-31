using strange.extensions.context.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class KolomboorRoot : ModuleRoot {

    private void Awake() {
        context = new KolomboorContext(this);
    }
}

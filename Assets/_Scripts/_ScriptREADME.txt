Arrow: attached to arrow, has colliders for target hits and points, has method to attach to bow (local to oculus)

Arrow copy: for photon, arrow follows hand (local to oculus)

Arrow manager: handles arrow and bow creation and hand attachment, arrow firing (local to oculus)

Bow copy: for photon, bow follows hand (local to oculus)

Chariot copy: for photon, chariot follows vive player bike (local to vive)

Chariot script: used to access bike object from instantiated chariot prefab (local to vive)

Copy script: attaches head prefab to player head (vive)

Enemy controller: used to instantiate enemies (oculus)

Enemy script: handles enemy animation, relays info to both users (oculus)

Hand selector: allows user to choose hand to hold bow in by grabbing, sets hand variables accordingly

Oculus copy script: attaches head prefab to player head (oculus)

Oculus manager: allows access to head and hands (oculus)

Oculus network manager: connects oculus player to photon network, instantiates head (oculus)

Point system: a unified point system with sychronized values (both)

Rider script: attaches oculus player to chariot's transform (oculus)

Test script: a script used to test methods from other scripts, to delete after development (N/A) 

Vive manager: allows access to head (vive)

Vive network manager: connects vive player to photon network, instantiates head (vive)

Vive rider script: makes oculus player child of vive player (vive)
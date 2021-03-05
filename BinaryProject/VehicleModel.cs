using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class VehicleModel
{
    public VehicleModel()
    {
        VehicleOverview = new VehicleOverview();
        engine = new Engine();
        starter = new Starter();
        gearBox = new GearBox();
        vehGearNum = 0;
        for (int i = 0; i < subGears.Length; i++) subGears[i] = new SubGear();
        windForce = new WindForce();
        steeringFactor = new SteeringFactor();
        steering = new Steering();
        fuelTank = new FuelTank();

        for (int i = 0; i < otherSteerings.Length; i++) otherSteerings[i] = new OtherSteering();
        carVibration = new CarVibration();
        brakesCommon = new Brakes();
        physicsCrashSetting = new PhysicsCrashSetting();
        ignoreHeadCollision = false;
        exhaust = new Exhaust();
        roughness = new Roughness();
        engineHealth = new EngineHealth();
        fuelTankOnCrash = 0;
        engineParticles = new EngineParticles();
        gearboxSettings = new GearboxSettings();
        wheels = new Wheel();
        body = new Body();
        bumper = new Bumper();
        windowGlass = new WindowGlass();
        light = new Light();
        licencePlate = new LicencePlate();
        mirror = new Mirror();
        wing = new Wing();
        door = new Door();
        roof = new Roof();
        unknown = new Unknown();
        engineSoundSet = new EngineSoundSet();
        engineSound1 = new EngineSound();
        engineSound2 = new EngineSound();
        engineSound3 = new EngineSound();
        engineSound4 = new EngineSound4();
        insideSoundSet = new InsideSoundSet();
        carSmallHitType = new CarSmallHitType();
        carShortCrashTypeB1 = new CarShortCrashType();
        carShortCrashWithGlassTypeC1 = new CarShortCrashType();
        unknownSound1 = "";
        unknownSound2 = "";
        engineStartSound = new EngineStartSound();
        engineSoundDriving = new EngineSoundDriving();
        for (int i = 0; i < engineSoundOnGears.Length; i++) engineSoundOnGears[i] = new EngineSoundOnGear();
        engineSoundIdle = new EngineSoundIdle();
        wheelSoundWhilePunctured = new WheelSoundWhilePunctured();
        carSmallHitType1 = new CarSmallHitType();
        carLongCrashType1 = new CarLongCrashType();
        carShortCrashWithGlassType1 = new CarShortCrashType();
        doorOpenCloseSound = new DoorOpenCloseSound();
        insideSoundSet = new InsideSoundSet();
        carSmallHitType = new CarSmallHitType();
        carLongCrashType2 = new CarLongCrashType();
        carShortCrashTypeB1 = new CarShortCrashType();
        carShortCrashWithGlassTypeC1 = new CarShortCrashType();
        unknownSound1 = "";
        unknownSound2 = "";
        carShortCrashTypeB2 = new CarShortCrashType();
        carShortCrashWithGlassType1 = new CarShortCrashType();
        doorOpenCloseSound = new DoorOpenCloseSound();
    }

  
    //Vehicle Overview
    public VehicleOverview VehicleOverview;

    //Engine
    public Engine engine;

    //Starter
    public Starter starter;

    //Gearbox Settings
    public GearBox gearBox;

    //Gears
    public float vehGearNum;

    public SubGear[] subGears = new SubGear[11];

    //Physics and Windforce
    public WindForce windForce;

    public SteeringFactor steeringFactor;

    public Steering steering;

    //Fuel Tank
    public FuelTank fuelTank;



    //Other Steering
    public OtherSteering[] otherSteerings = new OtherSteering[10];

    public CarVibration carVibration;

    public Brakes brakesCommon;

    public PhysicsCrashSetting physicsCrashSetting;

    public bool ignoreHeadCollision;

    public Exhaust exhaust;

    public Roughness roughness;
    public EngineHealth engineHealth;

    public float fuelTankOnCrash;

    public EngineParticles engineParticles;

    public GearboxSettings gearboxSettings;

    public Wheel wheels;

    public Body body;

    public Bumper bumper;

    public WindowGlass windowGlass;

    public Light light;

    public LicencePlate licencePlate;

    public Mirror mirror;

    public Wing wing;

    public Door door;

    public Roof roof;

    public Unknown unknown;

    public EngineSoundSet engineSoundSet;

    public EngineSound engineSound1;

    public EngineSound engineSound2;

    public EngineSound engineSound3;

    public EngineSound4 engineSound4;

    public InsideSoundSet insideSoundSet;

    public CarSmallHitType carSmallHitType1;

    public CarLongCrashType carLongCrashType1;

    public CarShortCrashType carShortCrashTypeB1;

    public CarShortCrashType carShortCrashWithGlassTypeC1;

    public string unknownSound1;

    public string unknownSound2;

    public EngineStartSound engineStartSound;


    public EngineSoundDriving engineSoundDriving;

    public EngineSoundOnGear[] engineSoundOnGears = new EngineSoundOnGear[10];

    public EngineSoundUnknown engineSoundUnknown = new EngineSoundUnknown();

    public EngineSoundUnknown engineSoundReverse = new EngineSoundUnknown();

    public EngineSoundUnknown engineSoundUnknown2 = new EngineSoundUnknown();

    public EngineSoundUnknown engineSoundUnknown3 = new EngineSoundUnknown();

    public EngineSoundUnknown engineSoundUnknown4 = new EngineSoundUnknown();

    public EngineSoundIdle engineSoundIdle;

    public WheelSoundWhilePunctured wheelSoundWhilePunctured;

    public EngineSoundSet2 engineSoundSet2 = new EngineSoundSet2();

    public CarSmallHitType carSmallHitType;

    public CarLongCrashType carLongCrashType2;

    public CarShortCrashType carShortCrashTypeB2;
    public CarShortCrashType carShortCrashWithGlassType1;

    
    public DoorOpenCloseSound doorOpenCloseSound;

}

[Serializable]
public class VehicleOverview
{
    public int vehicleBlockSize;
    public string vehModelName;
    public int vehProfileNum;
    public int vehProfileSize;
    public float vehWeight;
}

[Serializable]
public class Engine
{
    public float vehPowerGood;
    public float vehPowerCap;
    public float vehRPMRZMin;
    public float vehRPMRZMax;
    public float vehRPMIdle;
    public float vehTorgueGoodMax;
    public float vehTorgueGoodMin;
    public float vehTorqueHigh;
    public float vehRPMatTorqMin;
    public float vehRPMatTorqMax;
}


[Serializable]
public class SubGear
{
    public float vehGearRevRatio;
    public float vehGearRevUp;
    public float vehGearRevDo;
}

[Serializable]
public class ShockAbsorber
{
    public float suspensionStiffness;
    public float suspensionHeight;
    public float shockAbsorberStiffnessOnCompression;
    public float shockAbsorberStifnessOnDecompression;
}

[Serializable]
public class WindForce
{
    public float vehWindSide;
    public float vehWindFront;
}

[Serializable]
public class SteeringFactor
{
    public float vehOvSteerMin;
    public float vehOvSteerMax;
    public float vehUnSteerMin;
    public float vehUnSteerMax;
}

[Serializable]
public class Steering
{
    public float vehSteerAngleMax;
    public float vehSteerAngleMaxHigh;
    public float vehDifferentialAngle;
    public float vehSteerVelocity;
    public float vehSteerVelocityInit;
    public float vehSteerVeloDest;
    public float vehSteerVeloDestInit;
    public float vehPivotX;
    public float vehPivotY;
    public float vehPivotZ;
    public float vehGravity;
}

[Serializable]
public class FuelTank
{
    public float vehFuelCapacity;
    public float vehFuelConsump;
}

   
[Serializable]
public class Starter
{
    public float vehStarterRPM;
    public float vehStarterTime;
    public float vehFlywheelRPM;
}

[Serializable]
public class GearBox
{
    public float vehShiftTime;
    public float vehClutchTime;
    public float unknown;
    public float vehRPMGoodMin;
    public float vehRPMGoodMax;
}

[Serializable]
public class LocalSettings
{
    public float overSteer;
    public float underSteer;
    public float force;
    public float unknown;
    public float adhesion1;
    public float adhesion2;
    public float adhesion3;
    public float adhesion4;
    public float rollingFriction;
}

[Serializable]
public class OtherSteering
{
    public ShockAbsorber shockAbsorber = new ShockAbsorber();

    public int vehTyreProfile;
    public LocalSettings localSettingsOk = new LocalSettings();
    public LocalSettings localSettingsDefect = new LocalSettings();

    public float steeringRange;
    public bool isDrivingAxle;
    public bool isSteeringAxle;
    public bool hasHandbreak;
    public float breakEfficacyWheel1;
    public float breakEfficacyWheel2;
    public float pressureToDrawTireFloat;
    public float velocityToTireScreech;
    public float VelocityToTireScreechMax;
}

[Serializable]
public class CarVibration
{
    /// <summary>
    /// sharpness of vibrations along the vertical axis Y (the famous "fidget"))
    /// </summary>
    public float balance1;

    /// <summary>
    /// sharpness of oscillations along the longitudinal axis X (car tilt)
    /// </summary>
    public float balance2;

    /// <summary>
    /// sharpness of oscillations along the transverse axis Z (rocking car)
    /// </summary>
    public float balance3;
}

[Serializable]
public class Brakes
{
    public float brakeEfficacy;
    public float brakeBias;
    public float handbreakEfficacy;
    public float handbrakeBias;
}

[Serializable]
public class PhysicsCrashSetting
{
    public bool useCrashMultiplier;
    public float crashForceMultiplier;
    public float crashForceBackMultiplier;
    public int looseAdhesionFactor;
    public bool abs;
    public bool esp;
    public bool isInvisibleSteering;
    public float unknown;
}


[Serializable]
public class Exhaust
{
    public int particleModel;
    /// <summary>
    /// The speed at which the exhaust disappears
    /// </summary>
    public float particleOff;
    /// <summary>
    /// exhaust speed when car not moving
    /// </summary>
    public float particleVelocityIdle;
    /// <summary>
    /// exhaust speed when car not moving
    /// </summary>
    public float particleVelocityDriving;
    public float unknown1;
    public float unknown2;
    public float unknown3;
    public float unknown4;
}

[Serializable]
public class Roughness
{
    public bool useRoughness;
    public float sizeMax;
    public float sizeMin;
    public float heightMax;
    public float heightMin;
    public float intensity;
}

[Serializable]
public class EngineHealth
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
}

[Serializable]
public class EngineParticles
{
    public float particle2On;
    public float particle1On;
    public float particleOff;
    public int particle2;
    public int particle1;
}

[Serializable]
public class GearboxSettings
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
}

[Serializable]
public class Wheel
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float semiDestroyedAngle;
    public float damageToSemiDestroyed;
}

[Serializable]
public class Body
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float deformationByX;
    public float deformationByY;
    public float deformationByZ;
    public float directionResistanceByX;
    public float directionResistanceByY;
    public float directionResistanceByZ;
}

[Serializable]
public class Bumper
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float deformationByX;
    public float deformationByY;
    public float deformationByZ;
}

[Serializable]
public class WindowGlass
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float deformationByX;
    public float deformationByY;
    public float deformationByZ;
    public float damageToCrack;
    public string windowGlassTextureAlpha;
    public string windowGlasTextureAlphaBW;
}


[Serializable]
public class Light
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float unknown;
    public float deformationByX;
    public float deformationByY;
    public float deformationByZ;
}

[Serializable]
public class LicencePlate
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float deformationByX;
    public float deformationByY;
    public float deformationByZ;
}

[Serializable]
public class Mirror
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float deformationByX;
    public float deformationByY;
    public float deformationByZ;
}

[Serializable]
public class Wing
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float deformationByX;
    public float deformationByY;
    public float deformationByZ;
}

[Serializable]
public class Door
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float deformationByX;
    public float deformationByY;
    public float deformationByZ;
}

[Serializable]
public class Roof
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float deformationByX;
    public float deformationByY;
    public float deformationByZ;
}

[Serializable]
public class Unknown
{
    public float resistanceMelee;
    public float resistanceGuns;
    public float relativeHealth;
    public float absoluteHealth;
    public float deformationByX;
    public float deformationByY;
    public float deformationByZ;
}

[Serializable]
public class EngineSoundSet
{
    public bool isOn;
    public string engineOnSoundName;
    public string engineOffSoundName;
    public string engineOnNFSoundName;
}

[Serializable]
public class EngineSound
{
    public string soundName;
    public float playbackVelocityMin;
    public float playbackVelocityMax;
    public float volumeIdleStartMinimum;
    public float volumeIdleMaximum;
    public float vloumeDrivingStartMinimum;
    public float volumeDrivingMaximum;
    public float unknown1;
    public float unknown2;
    public bool isOn;
}

public class EngineSound4
{
    public string soundName;
    public float unknown1;
    public float unknown2;
    public string engineSoundInCar;
    public float unknown3;
    public float unknown4;
    public float unknown5;
    public float unknown6;
    public float unknown7;

}

[Serializable]
public class InsideSoundSet
{
    public string hornSoundFromInsideCar;
    public string unknown;
    public string handbreakSoundFromInsindeCar;
    public string gearChangeSoundInsideTheCar;
    public string gearChangeSoundInsideTheCar2;
    public string wheelSnipSoundInsideCar;
    public string brakeSoundInsideTheCar;
    public string carHitSoundInsideCar;
    public string unknown1;
    public string windowGlassSoundInsideCar;
}

[Serializable]
public class CarSmallHitType
{
    public string smallHitSoundFileLong;
    public string smallHitSoundFileShort;
    public float impactLevel;
    public bool unknown;
}

[Serializable]
public class CarLongCrashType
{
    public string longCrashSoundFileLong;
    public string longCrashSoundFileShort;
    public float impactLevel;
    public bool unknown;
}

[Serializable]
public class CarShortCrashType
{
    public string shortCrashSoundFileLong;
    public string shortCrashSoundFileShort;
    public float impactLevel;
    public bool unknown;
}

[Serializable]
public class UnknownSounds
{
    public string unknownSound1;
    public string unknownSound2;
}

[Serializable]
public class EngineStartSound
{
    public string start;
    public string stop;
    public string startBad;
}

[Serializable]
public class EngineSoundDriving
{
    public string fileSound;
    public float playBackVelocityMin;
    public float playBackVelocityMax;
    public float volumeIdle;
    public float volumeDriving;
}

[Serializable]
public class EngineSoundOnGear
{
    public string fileSound;
    public float playBackVelocityMin;
    public float playBackVelocityMax;
    public float volumeIdleStartMinimum;
    public float volumeIdleStartMaximum;
    public float volumeDrivingStartMinimum;
    public float volumeDrivingStartMaximum;
    public float unknown;
    public float unknown1;
    public bool unknown2;
}

[Serializable]
public class EngineSoundUnknown
{
    public string reverseEngineSound;
    public float playBackVelocityMin;
    public float playBackVelocityMax;
    public float volumeIdleStartMinimum;
    public float volumeIdleMaximum;
    public float volumeDrivingMinimum;
    public float volumeDrivingMaximum;
    public float unknown1;
    public float unknown2;
}

[Serializable]
public class EngineSoundIdle
{
    public string fileName;
    public float playBackVelocityMin;
    public float splaybackVelocityMax;
}

[Serializable]
public class WheelSoundWhilePunctured
{
    public string fileSound;
    public float unknown1;
    public float unknown2;
    public float unknown3;
    public float unknown4;
    public float unknown5;
}

[Serializable]
public class EngineSoundSet2
{
    public string hornSound;
    public string fileSound;
    public string handbrakeSound;
    public string changeGear;
    public string changeGear1;
    public string wheelSlipSound;
    public string handbreakSound;
    public string shockAbsorberSound;
    public string wheelPuncturedEventSound;
    public string carGlassBreaking;
}

[Serializable]
public class DoorOpenCloseSound
{
    public string doorOpenSoundFileName;
    public string doorCloseSoundFileName;
    public bool unknown1;
    public bool unknown2;
    public bool unknown3;
}

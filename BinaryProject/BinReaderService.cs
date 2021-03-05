using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BinaryProject
{
    public static class BinReaderService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binPath">Path to the bin file</param>
        /// <param name="jsonPath">Folder Where the json file should be created</param>
        /// <param name="shouldExportAsJson">If true, the bin file will be exported as json and saved in the specified path</param>
        public static  void ReadBinFile(string binPath, string jsonPath = "", bool shouldExportAsJson = false)
        {

           

            using (BinaryReader reader = new BinaryReader(File.Open(binPath, FileMode.Open)))
            {

                int fileSgn = BitConverter.ToInt32(reader.ReadBytes(4), 0);
                int numOfVehicles = BitConverter.ToInt32(reader.ReadBytes(4), 0);

                VehicleModel[] vehicles = new VehicleModel[89];
                VehicleModel model = new VehicleModel();

                for(int m = 0; m<89; m++)
                {
                    //reader.BaseStream.Position = 17725;
                    //Console.WriteLine(reader.ReadString());
                   // reader.BaseStream.Position = 17724;

                    model = new VehicleModel();
                    #region Overview
                    model.VehicleOverview.vehicleBlockSize = BitConverter.ToInt32(reader.ReadBytes(4), 0);
                    model.VehicleOverview.vehModelName = ReadNullTerminatedString(reader);
                    Console.WriteLine($"Exporting: {model.VehicleOverview.vehModelName}");
                    //Skip Padding
                    ReadEmptyBytes(reader);
                    model.VehicleOverview.vehProfileNum = BitConverter.ToInt32(reader.ReadBytes(4), 0);
                    model.VehicleOverview.vehProfileSize = BitConverter.ToInt32(reader.ReadBytes(4), 0);
                    model.VehicleOverview.vehWeight = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    #endregion

                    #region Engine
                    model.engine.vehPowerGood = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.engine.vehPowerCap = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.engine.vehRPMRZMin = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.engine.vehRPMRZMax = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.engine.vehRPMIdle = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.engine.vehTorgueGoodMax = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.engine.vehTorgueGoodMin = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.engine.vehTorqueHigh = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.engine.vehRPMatTorqMin = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.engine.vehRPMatTorqMax = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    #endregion


                    #region Starter
                    model.starter.vehStarterRPM = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.starter.vehStarterTime = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.starter.vehFlywheelRPM = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    #endregion

                    #region Gearbox
                    model.gearBox.vehShiftTime = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.gearBox.vehClutchTime = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.gearBox.unknown = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.gearBox.vehRPMGoodMin = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.gearBox.vehRPMGoodMax = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    #endregion

                    #region gears
                    model.vehGearNum = BitConverter.ToSingle(reader.ReadBytes(4), 0);


                    for (int i = 0; i < model.subGears.Length; i++)
                    {
                        model.subGears[i].vehGearRevRatio = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.subGears[i].vehGearRevUp = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.subGears[i].vehGearRevDo = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    }

                    #endregion

                    #region WindForce
                    model.windForce.vehWindSide = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.windForce.vehWindFront = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    #endregion

                    #region Steer Factor
                    model.steeringFactor.vehOvSteerMin = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steeringFactor.vehOvSteerMax = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steeringFactor.vehUnSteerMin = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steeringFactor.vehUnSteerMax = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    #endregion

                    #region Steering
                    model.steering.vehSteerAngleMax = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steering.vehSteerAngleMaxHigh = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steering.vehDifferentialAngle = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steering.vehSteerVelocity = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steering.vehSteerVelocityInit = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steering.vehSteerVeloDest = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steering.vehSteerVeloDestInit = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steering.vehPivotX = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steering.vehPivotY = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steering.vehPivotZ = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.steering.vehGravity = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    #endregion

                    #region Fuel Tank
                    model.fuelTank.vehFuelCapacity = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.fuelTank.vehFuelConsump = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    #endregion




                    #region Other Steering
                    for (int i = 0; i < model.otherSteerings.Length; i++)
                    {
                        
                        model.otherSteerings[i].shockAbsorber.suspensionStiffness = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].shockAbsorber.suspensionHeight = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].shockAbsorber.shockAbsorberStiffnessOnCompression = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].shockAbsorber.shockAbsorberStifnessOnDecompression = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].vehTyreProfile = BitConverter.ToInt32(reader.ReadBytes(4), 0);

                        model.otherSteerings[i].localSettingsOk.overSteer = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsOk.underSteer = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsOk.force = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsOk.unknown = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsOk.adhesion1 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsOk.adhesion2 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsOk.adhesion3 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsOk.adhesion4 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsOk.rollingFriction = BitConverter.ToSingle(reader.ReadBytes(4), 0);

                        model.otherSteerings[i].localSettingsDefect.overSteer = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsDefect.underSteer = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsDefect.force = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsDefect.unknown = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsDefect.adhesion1 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsDefect.adhesion2 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsDefect.adhesion3 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsDefect.adhesion4 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].localSettingsDefect.rollingFriction = BitConverter.ToSingle(reader.ReadBytes(4), 0);

                        model.otherSteerings[i].steeringRange = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].isDrivingAxle = BitConverter.ToBoolean(reader.ReadBytes(1), 0);
                        model.otherSteerings[i].isSteeringAxle = BitConverter.ToBoolean(reader.ReadBytes(1), 0);
                        model.otherSteerings[i].hasHandbreak = BitConverter.ToBoolean(reader.ReadBytes(1), 0);
                        model.otherSteerings[i].breakEfficacyWheel1 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].breakEfficacyWheel2 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].pressureToDrawTireFloat = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].velocityToTireScreech = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                        model.otherSteerings[i].VelocityToTireScreechMax = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    }
                    #endregion

                    #region Car Vibration
                    model.carVibration.balance1 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.carVibration.balance2 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.carVibration.balance3 = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    #endregion

                    #region Brakes Common
                    model.brakesCommon.brakeEfficacy = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.brakesCommon.brakeBias = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.brakesCommon.handbreakEfficacy = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    model.brakesCommon.handbrakeBias = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                    #endregion


                    #region physics Crash
                    model.physicsCrashSetting.useCrashMultiplier = ReadBool(reader);
                    model.physicsCrashSetting.crashForceMultiplier = ReadFloat(reader);
                    model.physicsCrashSetting.crashForceBackMultiplier = ReadFloat(reader);
                    model.physicsCrashSetting.looseAdhesionFactor = ReadInt32(reader);
                    model.physicsCrashSetting.abs = ReadBool(reader);
                    model.physicsCrashSetting.esp = ReadBool(reader);
                    model.physicsCrashSetting.isInvisibleSteering = ReadBool(reader);
                    model.physicsCrashSetting.unknown = ReadFloat(reader);
                    model.ignoreHeadCollision = ReadBool(reader);
                    #endregion

                    #region Exhaust
                    model.exhaust.particleModel = ReadInt32(reader);
                    model.exhaust.particleOff = ReadFloat(reader);
                    model.exhaust.particleVelocityIdle = ReadFloat(reader);
                    model.exhaust.particleVelocityDriving = ReadFloat(reader);
                    model.exhaust.unknown1 = ReadFloat(reader);
                    model.exhaust.unknown2 = ReadFloat(reader);
                    model.exhaust.unknown3 = ReadFloat(reader);
                    model.exhaust.unknown4 = ReadFloat(reader);
                    #endregion

                    #region Roughness
                    model.roughness.useRoughness = ReadBool(reader);
                    model.roughness.sizeMax = ReadFloat(reader);
                    model.roughness.sizeMin = ReadFloat(reader);
                    model.roughness.heightMax = ReadFloat(reader);
                    model.roughness.heightMin = ReadFloat(reader);
                    model.roughness.intensity = ReadFloat(reader);
                    #endregion

                    #region Engine Health
                    model.engineHealth.resistanceMelee = ReadFloat(reader);
                    model.engineHealth.resistanceGuns = ReadFloat(reader);
                    model.engineHealth.relativeHealth = ReadFloat(reader);
                    model.engineHealth.absoluteHealth = ReadFloat(reader);
                    model.fuelTankOnCrash = ReadFloat(reader);
                    #endregion

                    #region Engine Particles
                    model.engineParticles.particle2On = ReadFloat(reader);
                    model.engineParticles.particle1On = ReadFloat(reader);
                    model.engineParticles.particleOff = ReadFloat(reader);
                    model.engineParticles.particle2 = ReadInt32(reader);
                    model.engineParticles.particle1 = ReadInt32(reader);
                    #endregion

                    #region Gear box Settings
                    model.gearboxSettings.resistanceMelee = ReadFloat(reader);
                    model.gearboxSettings.resistanceGuns = ReadFloat(reader);
                    model.gearboxSettings.relativeHealth = ReadFloat(reader);
                    model.gearboxSettings.absoluteHealth = ReadFloat(reader);
                    #endregion

                    #region Wheels
                    model.wheels.resistanceMelee = ReadFloat(reader);
                    model.wheels.resistanceGuns = ReadFloat(reader);
                    model.wheels.relativeHealth = ReadFloat(reader);
                    model.wheels.absoluteHealth = ReadFloat(reader);
                    model.wheels.semiDestroyedAngle = ReadFloat(reader);
                    model.wheels.damageToSemiDestroyed = ReadFloat(reader);
                    #endregion

                    #region Body
                    model.body.resistanceMelee = ReadFloat(reader);
                    model.body.resistanceGuns = ReadFloat(reader);
                    model.body.relativeHealth = ReadFloat(reader);
                    model.body.absoluteHealth = ReadFloat(reader);
                    model.body.deformationByX = ReadFloat(reader);
                    model.body.deformationByY = ReadFloat(reader);
                    model.body.deformationByZ = ReadFloat(reader);
                    model.body.directionResistanceByX = ReadFloat(reader);
                    model.body.directionResistanceByY = ReadFloat(reader);
                    model.body.directionResistanceByZ = ReadFloat(reader);
                    #endregion

                    #region Bumper
                    model.bumper.resistanceMelee = ReadFloat(reader);
                    model.bumper.resistanceGuns = ReadFloat(reader);
                    model.bumper.relativeHealth = ReadFloat(reader);
                    model.bumper.absoluteHealth = ReadFloat(reader);
                    model.bumper.deformationByX = ReadFloat(reader);
                    model.bumper.deformationByY = ReadFloat(reader);
                    model.bumper.deformationByZ = ReadFloat(reader);
                    #endregion

                    #region Window Glass
                    model.windowGlass.resistanceMelee = ReadFloat(reader);
                    model.windowGlass.resistanceGuns = ReadFloat(reader);
                    model.windowGlass.relativeHealth = ReadFloat(reader);
                    model.windowGlass.absoluteHealth = ReadFloat(reader);
                    model.windowGlass.deformationByX = ReadFloat(reader);
                    model.windowGlass.deformationByY = ReadFloat(reader);
                    model.windowGlass.deformationByZ = ReadFloat(reader);
                    model.windowGlass.damageToCrack = ReadFloat(reader);
                    model.windowGlass.windowGlassTextureAlpha = ReadStringInFixedBytes(reader, 15);
                    model.windowGlass.windowGlasTextureAlphaBW = ReadStringInFixedBytes(reader, 15);
                    #endregion

                    #region Light
                    model.light.resistanceMelee = ReadFloat(reader);
                    model.light.resistanceGuns = ReadFloat(reader);
                    model.light.relativeHealth = ReadFloat(reader);
                    model.light.absoluteHealth = ReadFloat(reader);
                    model.light.unknown = ReadFloat(reader);
                    model.light.deformationByX = ReadFloat(reader);
                    model.light.deformationByY = ReadFloat(reader);
                    model.light.deformationByZ = ReadFloat(reader);
                    #endregion

                    #region License Plate
                    model.licencePlate.resistanceMelee = ReadFloat(reader);
                    model.licencePlate.resistanceGuns = ReadFloat(reader);
                    model.licencePlate.relativeHealth = ReadFloat(reader);
                    model.licencePlate.absoluteHealth = ReadFloat(reader);
                    model.licencePlate.deformationByX = ReadFloat(reader);
                    model.licencePlate.deformationByY = ReadFloat(reader);
                    model.licencePlate.deformationByZ = ReadFloat(reader);
                    #endregion

                    #region Mirror
                    model.mirror.resistanceMelee = ReadFloat(reader);
                    model.mirror.resistanceGuns = ReadFloat(reader);
                    model.mirror.relativeHealth = ReadFloat(reader);
                    model.mirror.absoluteHealth = ReadFloat(reader);
                    model.mirror.deformationByX = ReadFloat(reader);
                    model.mirror.deformationByY = ReadFloat(reader);
                    model.mirror.deformationByZ = ReadFloat(reader);
                    #endregion

                    #region Wing
                    model.wing.resistanceMelee = ReadFloat(reader);
                    model.wing.resistanceGuns = ReadFloat(reader);
                    model.wing.relativeHealth = ReadFloat(reader);
                    model.wing.absoluteHealth = ReadFloat(reader);
                    model.wing.deformationByX = ReadFloat(reader);
                    model.wing.deformationByY = ReadFloat(reader);
                    model.wing.deformationByZ = ReadFloat(reader);
                    #endregion

                    #region Door
                    model.door.resistanceMelee = ReadFloat(reader);
                    model.door.resistanceGuns = ReadFloat(reader);
                    model.door.relativeHealth = ReadFloat(reader);
                    model.door.absoluteHealth = ReadFloat(reader);
                    model.door.deformationByX = ReadFloat(reader);
                    model.door.deformationByY = ReadFloat(reader);
                    model.door.deformationByZ = ReadFloat(reader);
                    #endregion

                    #region Roof
                    model.roof.resistanceMelee = ReadFloat(reader);
                    model.roof.resistanceGuns = ReadFloat(reader);
                    model.roof.relativeHealth = ReadFloat(reader);
                    model.roof.absoluteHealth = ReadFloat(reader);
                    model.roof.deformationByX = ReadFloat(reader);
                    model.roof.deformationByY = ReadFloat(reader);
                    model.roof.deformationByZ = ReadFloat(reader);
                    #endregion

                    #region Unknown
                    model.unknown.resistanceMelee = ReadFloat(reader);
                    model.unknown.resistanceGuns = ReadFloat(reader);
                    model.unknown.relativeHealth = ReadFloat(reader);
                    model.unknown.absoluteHealth = ReadFloat(reader);
                    model.unknown.deformationByX = ReadFloat(reader);
                    model.unknown.deformationByY = ReadFloat(reader);
                    model.unknown.deformationByZ = ReadFloat(reader);
                    #endregion

                    #region Engine Sound Inside Car
                    model.engineSoundSet.isOn = ReadBool(reader);
                    model.engineSoundSet.engineOnSoundName = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet.engineOffSoundName = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet.engineOnNFSoundName = ReadLengthCharacterString(reader, 16);

                    model.engineSound1.soundName = ReadLengthCharacterString(reader, 16);
                    model.engineSound1.playbackVelocityMin = ReadFloat(reader);
                    model.engineSound1.playbackVelocityMax = ReadFloat(reader);
                    model.engineSound1.volumeIdleStartMinimum = ReadFloat(reader);
                    model.engineSound1.volumeIdleMaximum = ReadFloat(reader);
                    model.engineSound1.vloumeDrivingStartMinimum = ReadFloat(reader);
                    model.engineSound1.volumeDrivingMaximum = ReadFloat(reader);
                    model.engineSound1.unknown1 = ReadFloat(reader);
                    model.engineSound1.unknown2 = ReadFloat(reader);
                    reader.ReadBytes(196);
                    model.engineSound1.isOn = ReadBool(reader);

                    model.engineSound2.soundName = ReadLengthCharacterString(reader, 16);
                    model.engineSound2.playbackVelocityMin = ReadFloat(reader);
                    model.engineSound2.playbackVelocityMax = ReadFloat(reader);
                    model.engineSound2.volumeIdleStartMinimum = ReadFloat(reader);
                    model.engineSound2.volumeIdleMaximum = ReadFloat(reader);
                    model.engineSound2.vloumeDrivingStartMinimum = ReadFloat(reader);
                    model.engineSound2.volumeDrivingMaximum = ReadFloat(reader);
                    model.engineSound2.unknown1 = ReadFloat(reader);
                    model.engineSound2.unknown2 = ReadFloat(reader);
                    reader.ReadBytes(196);
                    model.engineSound2.isOn = ReadBool(reader);

                    model.engineSound3.soundName = ReadLengthCharacterString(reader, 16);
                    model.engineSound3.playbackVelocityMin = ReadFloat(reader);
                    model.engineSound3.playbackVelocityMax = ReadFloat(reader);
                    model.engineSound3.volumeIdleStartMinimum = ReadFloat(reader);
                    model.engineSound3.volumeIdleMaximum = ReadFloat(reader);
                    model.engineSound3.vloumeDrivingStartMinimum = ReadFloat(reader);
                    model.engineSound3.volumeDrivingMaximum = ReadFloat(reader);
                    model.engineSound3.unknown1 = ReadFloat(reader);
                    model.engineSound3.unknown2 = ReadFloat(reader);
                    reader.ReadBytes(191);
                    model.engineSound3.isOn = ReadBool(reader);

                    model.engineSound4.soundName = ReadLengthCharacterString(reader, 16);
                    model.engineSound4.unknown1 = ReadFloat(reader);
                    model.engineSound4.unknown2 = ReadFloat(reader);
                    model.engineSound4.engineSoundInCar = ReadLengthCharacterString(reader, 16);
                    model.engineSound4.unknown3 = ReadFloat(reader);
                    model.engineSound4.unknown4 = ReadFloat(reader);
                    model.engineSound4.unknown5 = ReadFloat(reader);
                    model.engineSound4.unknown6 = ReadFloat(reader);
                    model.engineSound4.unknown7 = ReadFloat(reader);

                    model.insideSoundSet.hornSoundFromInsideCar = ReadLengthCharacterString(reader, 16);
                    model.insideSoundSet.unknown = ReadLengthCharacterString(reader, 16);
                    model.insideSoundSet.handbreakSoundFromInsindeCar = ReadLengthCharacterString(reader, 16);
                    model.insideSoundSet.gearChangeSoundInsideTheCar = ReadLengthCharacterString(reader, 16);
                    model.insideSoundSet.gearChangeSoundInsideTheCar2 = ReadLengthCharacterString(reader, 16);
                    model.insideSoundSet.wheelSnipSoundInsideCar = ReadLengthCharacterString(reader, 16);
                    model.insideSoundSet.brakeSoundInsideTheCar = ReadLengthCharacterString(reader, 16);
                    model.insideSoundSet.carHitSoundInsideCar = ReadLengthCharacterString(reader, 16);
                    model.insideSoundSet.unknown1 = ReadLengthCharacterString(reader, 16);
                    model.insideSoundSet.windowGlassSoundInsideCar = ReadLengthCharacterString(reader, 16);

                    model.carSmallHitType1.smallHitSoundFileLong = ReadLengthCharacterString(reader, 16);
                    model.carSmallHitType1.smallHitSoundFileShort = ReadLengthCharacterString(reader, 16);
                    model.carSmallHitType1.impactLevel = ReadFloat(reader);
                    model.carSmallHitType1.unknown = ReadBool(reader);

                    model.carLongCrashType1.longCrashSoundFileLong = ReadLengthCharacterString(reader, 16);
                    model.carLongCrashType1.longCrashSoundFileShort = ReadLengthCharacterString(reader, 16);
                    model.carLongCrashType1.impactLevel = ReadFloat(reader);
                    model.carLongCrashType1.unknown = ReadBool(reader);

                    model.carShortCrashTypeB1.shortCrashSoundFileLong = ReadLengthCharacterString(reader, 16);
                    model.carShortCrashTypeB1.shortCrashSoundFileShort = ReadLengthCharacterString(reader, 16);
                    model.carShortCrashTypeB1.impactLevel = ReadFloat(reader);
                    model.carShortCrashTypeB1.unknown = ReadBool(reader);

                    model.carShortCrashWithGlassTypeC1.shortCrashSoundFileShort = ReadLengthCharacterString(reader, 16);
                    model.carShortCrashWithGlassTypeC1.shortCrashSoundFileLong = ReadLengthCharacterString(reader, 16);
                    model.carShortCrashWithGlassTypeC1.impactLevel = ReadFloat(reader);
                    model.carShortCrashWithGlassTypeC1.unknown = ReadBool(reader);

                    model.unknownSound1 = ReadLengthCharacterString(reader, 16);
                    model.unknownSound2 = ReadLengthCharacterString(reader, 16);

                    model.engineStartSound.start = ReadLengthCharacterString(reader, 16);
                    model.engineStartSound.stop = ReadLengthCharacterString(reader, 16);
                    model.engineStartSound.startBad = ReadLengthCharacterString(reader, 16);

                    model.engineSoundDriving.fileSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundDriving.playBackVelocityMin = ReadFloat(reader);
                    model.engineSoundDriving.playBackVelocityMax = ReadFloat(reader);
                    model.engineSoundDriving.volumeIdle = ReadFloat(reader);
                    model.engineSoundDriving.volumeDriving = ReadFloat(reader);

                    for (int i = 0; i < model.engineSoundOnGears.Length; i++)
                    {
                        model.engineSoundOnGears[i].fileSound = ReadLengthCharacterString(reader, 16);
                        model.engineSoundOnGears[i].playBackVelocityMin = ReadFloat(reader);
                        model.engineSoundOnGears[i].playBackVelocityMax = ReadFloat(reader);
                        model.engineSoundOnGears[i].volumeIdleStartMinimum = ReadFloat(reader);
                        model.engineSoundOnGears[i].volumeIdleStartMaximum = ReadFloat(reader);
                        model.engineSoundOnGears[i].volumeDrivingStartMinimum = ReadFloat(reader);
                        model.engineSoundOnGears[i].volumeDrivingStartMaximum = ReadFloat(reader);
                        model.engineSoundOnGears[i].unknown = ReadFloat(reader);
                        model.engineSoundOnGears[i].unknown1 = ReadFloat(reader);
                        model.engineSoundOnGears[i].unknown2 = ReadBool(reader);
                    }

                    model.engineSoundUnknown.reverseEngineSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundUnknown.playBackVelocityMin = ReadFloat(reader);
                    model.engineSoundUnknown.playBackVelocityMax = ReadFloat(reader);
                    model.engineSoundUnknown.volumeIdleStartMinimum = ReadFloat(reader);
                    model.engineSoundUnknown.volumeIdleMaximum = ReadFloat(reader);
                    model.engineSoundUnknown.volumeDrivingMinimum = ReadFloat(reader);
                    model.engineSoundUnknown.volumeDrivingMaximum = ReadFloat(reader);
                    model.engineSoundUnknown.unknown1 = ReadFloat(reader);
                    model.engineSoundUnknown.unknown2 = ReadFloat(reader);

                    model.engineSoundReverse.reverseEngineSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundReverse.playBackVelocityMin = ReadFloat(reader);
                    model.engineSoundReverse.playBackVelocityMax = ReadFloat(reader);
                    model.engineSoundReverse.volumeIdleStartMinimum = ReadFloat(reader);
                    model.engineSoundReverse.volumeIdleMaximum = ReadFloat(reader);
                    model.engineSoundReverse.volumeDrivingMinimum = ReadFloat(reader);
                    model.engineSoundReverse.volumeDrivingMaximum = ReadFloat(reader);
                    model.engineSoundReverse.unknown1 = ReadFloat(reader);
                    model.engineSoundReverse.unknown2 = ReadFloat(reader);

                    model.engineSoundUnknown2.reverseEngineSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundUnknown2.playBackVelocityMin = ReadFloat(reader);
                    model.engineSoundUnknown2.playBackVelocityMax = ReadFloat(reader);
                    model.engineSoundUnknown2.volumeIdleStartMinimum = ReadFloat(reader);
                    model.engineSoundUnknown2.volumeIdleMaximum = ReadFloat(reader);
                    model.engineSoundUnknown2.volumeDrivingMinimum = ReadFloat(reader);
                    model.engineSoundUnknown2.volumeDrivingMaximum = ReadFloat(reader);
                    model.engineSoundUnknown2.unknown1 = ReadFloat(reader);
                    model.engineSoundUnknown2.unknown2 = ReadFloat(reader);

                    model.engineSoundUnknown3.reverseEngineSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundUnknown3.playBackVelocityMin = ReadFloat(reader);
                    model.engineSoundUnknown3.playBackVelocityMax = ReadFloat(reader);
                    model.engineSoundUnknown3.volumeIdleStartMinimum = ReadFloat(reader);
                    model.engineSoundUnknown3.volumeIdleMaximum = ReadFloat(reader);
                    model.engineSoundUnknown3.volumeDrivingMinimum = ReadFloat(reader);
                    model.engineSoundUnknown3.volumeDrivingMaximum = ReadFloat(reader);
                    model.engineSoundUnknown3.unknown1 = ReadFloat(reader);
                    model.engineSoundUnknown3.unknown2 = ReadFloat(reader);

                    model.engineSoundUnknown4.reverseEngineSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundUnknown4.playBackVelocityMin = ReadFloat(reader);
                    model.engineSoundUnknown4.playBackVelocityMax = ReadFloat(reader);
                    model.engineSoundUnknown4.volumeIdleStartMinimum = ReadFloat(reader);
                    model.engineSoundUnknown4.volumeIdleMaximum = ReadFloat(reader);
                    model.engineSoundUnknown4.volumeDrivingMinimum = ReadFloat(reader);
                    model.engineSoundUnknown4.volumeDrivingMaximum = ReadFloat(reader);
                    model.engineSoundUnknown4.unknown1 = ReadFloat(reader);
                    model.engineSoundUnknown4.unknown2 = ReadFloat(reader);

                    model.engineSoundIdle.fileName = ReadLengthCharacterString(reader, 16);
                    model.engineSoundIdle.playBackVelocityMin = ReadFloat(reader);
                    model.engineSoundIdle.splaybackVelocityMax = ReadFloat(reader);

                    model.wheelSoundWhilePunctured.fileSound = ReadLengthCharacterString(reader, 16);
                    model.wheelSoundWhilePunctured.unknown1 = ReadFloat(reader);
                    model.wheelSoundWhilePunctured.unknown2 = ReadFloat(reader);
                    model.wheelSoundWhilePunctured.unknown3 = ReadFloat(reader);
                    model.wheelSoundWhilePunctured.unknown4 = ReadFloat(reader);
                    model.wheelSoundWhilePunctured.unknown5 = ReadFloat(reader);

                    model.engineSoundSet2.hornSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet2.fileSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet2.handbrakeSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet2.changeGear = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet2.changeGear1 = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet2.wheelSlipSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet2.handbreakSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet2.shockAbsorberSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet2.wheelPuncturedEventSound = ReadLengthCharacterString(reader, 16);
                    model.engineSoundSet2.carGlassBreaking = ReadLengthCharacterString(reader, 16);

                    model.carSmallHitType.smallHitSoundFileLong = ReadLengthCharacterString(reader, 16);
                    model.carSmallHitType.smallHitSoundFileShort = ReadLengthCharacterString(reader, 16);
                    model.carSmallHitType.impactLevel = ReadFloat(reader);
                    model.carSmallHitType.unknown = ReadBool(reader);

                    model.carLongCrashType2.longCrashSoundFileLong = ReadLengthCharacterString(reader, 16);
                    model.carLongCrashType2.longCrashSoundFileShort = ReadLengthCharacterString(reader, 16);
                    model.carLongCrashType2.impactLevel = ReadFloat(reader);
                    model.carLongCrashType2.unknown = ReadBool(reader);

                    model.carShortCrashTypeB2.shortCrashSoundFileLong = ReadLengthCharacterString(reader, 16);
                    model.carShortCrashTypeB2.shortCrashSoundFileShort = ReadLengthCharacterString(reader, 16);
                    model.carShortCrashTypeB2.impactLevel = ReadFloat(reader);
                    model.carShortCrashTypeB2.unknown = ReadBool(reader);

                    model.carShortCrashWithGlassType1.shortCrashSoundFileLong = ReadLengthCharacterString(reader, 16);
                    model.carShortCrashWithGlassType1.shortCrashSoundFileShort = ReadLengthCharacterString(reader, 16);
                    model.carShortCrashWithGlassType1.impactLevel = ReadFloat(reader);
                    model.carShortCrashWithGlassType1.unknown = ReadBool(reader);

                    model.doorOpenCloseSound.doorOpenSoundFileName = ReadLengthCharacterString(reader, 16);
                    model.doorOpenCloseSound.doorCloseSoundFileName = ReadLengthCharacterString(reader, 16);
                    model.doorOpenCloseSound.unknown1 = ReadBool(reader);
                    model.doorOpenCloseSound.unknown2 = ReadBool(reader);
                    model.doorOpenCloseSound.unknown3 = ReadBool(reader);

                    #endregion

                    vehicles[m] = model;
                    reader.ReadBytes(model.VehicleOverview.vehicleBlockSize - 4425);
                    reader.ReadBytes(1);
                }



                if (shouldExportAsJson) ExportAsJson(vehicles, jsonPath);
            }


            

        }


  

        static bool ReadBool(this System.IO.BinaryReader stream)
        {
            return BitConverter.ToBoolean(stream.ReadBytes(1), 0);
        }

        static int ReadInt32(this System.IO.BinaryReader stream)
        {
            return BitConverter.ToInt32(stream.ReadBytes(4), 0);
        }

        static float ReadFloat(this System.IO.BinaryReader stream)
        {
            return BitConverter.ToSingle(stream.ReadBytes(4), 0);
        }

        static string ReadNullTerminatedString(this System.IO.BinaryReader stream)
        {
            string str = "";
            char ch;
            try
            {
                while ((int)(ch = stream.ReadChar()) != 0)
                {

                    str = str + ch;
                }
            }
            catch (Exception ex)
            {

            }


            return str;
        }

        static string ReadLengthCharacterString(this System.IO.BinaryReader stream, int maxLength)
        {
            string str = ReadNullTerminatedString(stream);
            int stringCount = str.Length;
            //Check if the length is greater than the max length
            if(stringCount > maxLength)
            {
                str = str.Substring(0, maxLength);
                int newCount = str.Length;
                int diff = stringCount - newCount;
                stream.BaseStream.Position -= (diff+1);
            }
            else
            {
                int posSkip = maxLength - stringCount;
                if (posSkip > 0) stream.ReadBytes(posSkip-1);
            }
            
            return str;
        }

        static string ReadStringInFixedBytes(this System.IO.BinaryReader stream, int byteLength)
        {
            string str;
            str = ReadNullTerminatedString(stream);
            int byteCount = System.Text.ASCIIEncoding.ASCII.GetByteCount(str);
            int extraBytes = byteLength - byteCount;
            if (extraBytes > 0) stream.ReadBytes(extraBytes);
            return str;
        }
       
        static void ReadEmptyBytes(this System.IO.BinaryReader stream)
        {
            while (true)
            {
                byte b = stream.ReadByte();
                if (b != 0)
                {
                    stream.BaseStream.Position--;
                    break;
                }
            }
            

        }
        static void ExportAsJson<T>(T model, string pathToJson)
        {
            Console.WriteLine("Exporting Json...");
            pathToJson += @"Vehicles.json";
            
            string jsonString = JsonConvert.SerializeObject(model);

            // Check if file already exists. If yes, delete it.     
            if (File.Exists(@pathToJson))
            {
                File.Delete(pathToJson);
            }

            using (FileStream fs = File.Create(pathToJson))
            {
                // Add some text to file    
                Byte[] title = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(model, Formatting.Indented));
                fs.Write(title, 0, title.Length);
          
            }

            Console.WriteLine($"Exported to {pathToJson}");
        }

        //REad the Integer here
    }
}

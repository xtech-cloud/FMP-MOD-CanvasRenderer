
@echo off

REM !!! Generated by the fmp-cli 1.83.0.  DO NOT EDIT!

md CanvasRenderer\Assets\3rd\fmp-xtc-canvasrenderer

cd ..\vs2022
dotnet build -c Release

copy fmp-xtc-canvasrenderer-lib-mvcs\bin\Release\netstandard2.1\*.dll ..\unity2021\CanvasRenderer\Assets\3rd\fmp-xtc-canvasrenderer\

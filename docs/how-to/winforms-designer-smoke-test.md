# Windows Forms Designer Smoke Test

## Scope

This is the manual verification record for the `PipelineOrchestrator.UI`
Designer boundary required by M01-SS01 / issue #2.

## Procedure (Windows + Visual Studio 2022)

1. Open `PipelineOrchestrator.sln` in Visual Studio 2022.
2. Open `PipelineOrchestrator.UI/MainForm.cs` in the Windows Forms Designer.
3. Confirm the generated surface is provided by `MainForm.Designer.cs`.
4. Make a reversible designer change, save the form, and reopen it.
5. Confirm the form still loads and business logic remains in `MainForm.cs`.

## Evidence record

- **Status:** Not run in this Linux agent environment.
- **Required operator:** Windows developer with Visual Studio 2022.
- **Expected result:** Designer opens and saves `MainForm` without moving business logic into generated code.
- **Artifact location:** Attach the Visual Studio screenshot or test record to issue #2 / PR #206 when executed.

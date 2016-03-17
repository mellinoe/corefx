// Metadata version: v4.0.30319
.assembly extern System.Runtime
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 4:0:0:0
}
.assembly System.Unsafe
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                   63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [System.Runtime]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .custom instance void [System.Runtime]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [System.Runtime]System.Reflection.AssemblyInformationalVersionAttribute::.ctor(string) = ( 01 00 05 31 2E 30 2E 30 00 00 )                   // ...1.0.0..
  .custom instance void [System.Runtime]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 14 44 4E 58 43 6F 72 65 2C 56 65 72 73 69   // ...DNXCore,Versi
                                                                                                              6F 6E 3D 76 35 2E 30 00 00 )                      // on=v5.0..
  .hash algorithm 0x00008004
  .ver 4:0:0:0
}
.module System.Unsafe.dll
// MVID: {1E97D84A-565B-49C5-B60A-F31A1A4ACE13}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x02ED0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed beforefieldinit System.Unsafe
       extends [System.Runtime]System.Object
{
  .method public hidebysig static !!T  Read<T>(void* p) cil managed aggressiveinlining
  {
         .maxstack  8
          ldarg.0
          ldobj !!T
          ret
  } // end of method Unsafe::Read

  .method public hidebysig static void  Write<T>(void* p,
                                                 !!T 'value') cil managed aggressiveinlining
  {
         .maxstack  8
          ldarg.0
          ldarg.1
          stobj !!T
          ret
  } // end of method Unsafe::Write

  .method public hidebysig static void*  AddressOf<T>(!!T& 'value') cil managed aggressiveinlining
  {
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0002:  ret
  } // end of method Unsafe::AddressOf

  .method public hidebysig static int32  SizeOf<T>() cil managed aggressiveinlining
  {
    .maxstack  8
    sizeof !!T
    ret
  } // end of method Unsafe::SizeOf

} // end of class System.Unsafe

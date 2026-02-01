| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 128B         |     670.1 ns |     1.92 ns |     1.80 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 128B         |     739.7 ns |     4.63 ns |     4.33 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 137B         |     667.6 ns |     1.98 ns |     1.85 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 137B         |     743.6 ns |     5.58 ns |     4.94 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 1KB          |   3,599.9 ns |    10.08 ns |     8.94 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 1KB          |   4,025.9 ns |    51.87 ns |    48.52 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 1025B        |   3,603.6 ns |     9.58 ns |     8.49 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 1025B        |   4,024.5 ns |    30.46 ns |    27.00 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 8KB          |  26,589.8 ns |    68.87 ns |    64.42 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 8KB          |  30,343.5 ns |   204.91 ns |   171.11 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 128KB        | 423,379.0 ns |   990.16 ns |   877.75 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 128KB        | 478,690.0 ns | 2,852.09 ns | 2,667.84 ns |      96 B |
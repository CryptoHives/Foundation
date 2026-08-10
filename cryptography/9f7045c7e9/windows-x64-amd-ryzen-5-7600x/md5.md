| Description                            | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · MD5 · MD5 (OS)           | 128B         |     296.1 ns |   0.68 ns |   0.63 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 128B         |     348.7 ns |   2.13 ns |   1.99 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 128B         |     391.8 ns |   0.67 ns |   0.60 ns |      80 B |
|                                        |              |              |           |           |           |
| ComputeHash · MD5 · MD5 (OS)           | 137B         |     332.7 ns |   0.53 ns |   0.50 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 137B         |     353.6 ns |   2.91 ns |   2.72 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 137B         |     391.9 ns |   1.30 ns |   1.22 ns |      80 B |
|                                        |              |              |           |           |           |
| ComputeHash · MD5 · MD5 (OS)           | 1KB          |   1,466.1 ns |   2.11 ns |   1.97 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 1KB          |   1,818.0 ns |   6.57 ns |   5.82 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 1KB          |   2,030.5 ns |   6.44 ns |   6.02 ns |      80 B |
|                                        |              |              |           |           |           |
| ComputeHash · MD5 · MD5 (OS)           | 1025B        |   1,393.7 ns |   1.93 ns |   1.71 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 1025B        |   1,828.5 ns |  13.17 ns |  12.31 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 1025B        |   2,030.5 ns |   5.14 ns |   4.56 ns |      80 B |
|                                        |              |              |           |           |           |
| ComputeHash · MD5 · MD5 (OS)           | 8KB          |  10,182.9 ns |  15.50 ns |  14.50 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 8KB          |  13,632.6 ns |  59.71 ns |  52.93 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 8KB          |  15,112.9 ns |  32.66 ns |  30.55 ns |      80 B |
|                                        |              |              |           |           |           |
| ComputeHash · MD5 · MD5 (OS)           | 128KB        | 160,818.5 ns | 181.83 ns | 170.08 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 128KB        | 214,579.5 ns | 990.53 ns | 926.55 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 128KB        | 238,709.4 ns | 376.26 ns | 333.55 ns |      80 B |
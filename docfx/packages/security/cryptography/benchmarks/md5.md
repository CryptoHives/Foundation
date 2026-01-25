| Description                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | MD5 | MD5 (OS)           | 128B         |     293.3 ns |     0.79 ns |     0.74 ns |      80 B |
| ComputeHash | MD5 | MD5 (Managed)      | 128B         |     351.9 ns |     2.16 ns |     2.02 ns |      80 B |
| ComputeHash | MD5 | MD5 (BouncyCastle) | 128B         |     392.4 ns |     0.93 ns |     0.83 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash | MD5 | MD5 (OS)           | 137B         |     291.5 ns |     0.65 ns |     0.61 ns |      80 B |
| ComputeHash | MD5 | MD5 (Managed)      | 137B         |     353.6 ns |     2.53 ns |     2.37 ns |      80 B |
| ComputeHash | MD5 | MD5 (BouncyCastle) | 137B         |     390.1 ns |     1.24 ns |     1.16 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash | MD5 | MD5 (OS)           | 1KB          |   1,392.5 ns |     2.63 ns |     2.46 ns |      80 B |
| ComputeHash | MD5 | MD5 (Managed)      | 1KB          |   1,823.1 ns |    15.16 ns |    14.18 ns |      80 B |
| ComputeHash | MD5 | MD5 (BouncyCastle) | 1KB          |   2,031.2 ns |     4.91 ns |     4.60 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash | MD5 | MD5 (OS)           | 1025B        |   1,392.7 ns |     1.82 ns |     1.61 ns |      80 B |
| ComputeHash | MD5 | MD5 (Managed)      | 1025B        |   1,827.4 ns |    13.50 ns |    12.63 ns |      80 B |
| ComputeHash | MD5 | MD5 (BouncyCastle) | 1025B        |   2,031.0 ns |     5.43 ns |     4.81 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash | MD5 | MD5 (OS)           | 8KB          |  10,187.2 ns |    17.05 ns |    15.95 ns |      80 B |
| ComputeHash | MD5 | MD5 (Managed)      | 8KB          |  13,591.7 ns |   121.10 ns |   107.35 ns |      80 B |
| ComputeHash | MD5 | MD5 (BouncyCastle) | 8KB          |  15,112.4 ns |    26.37 ns |    24.67 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash | MD5 | MD5 (OS)           | 128KB        | 160,940.4 ns |   233.76 ns |   218.66 ns |      80 B |
| ComputeHash | MD5 | MD5 (Managed)      | 128KB        | 215,288.0 ns | 1,213.07 ns | 1,134.71 ns |      80 B |
| ComputeHash | MD5 | MD5 (BouncyCastle) | 128KB        | 238,902.8 ns |   617.12 ns |   577.26 ns |      80 B |
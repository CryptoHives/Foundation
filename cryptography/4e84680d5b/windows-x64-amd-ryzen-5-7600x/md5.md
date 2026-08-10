| Description                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · MD5 · MD5 (OS)           | 128B         |     294.1 ns |     1.99 ns |     1.86 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 128B         |     358.3 ns |     4.18 ns |     3.70 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 128B         |     393.7 ns |     1.27 ns |     1.13 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 137B         |     290.7 ns |     1.23 ns |     1.15 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 137B         |     356.7 ns |     3.22 ns |     2.85 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 137B         |     392.9 ns |     1.74 ns |     1.63 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 1KB          |   1,396.7 ns |     4.28 ns |     4.01 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 1KB          |   1,838.7 ns |    11.41 ns |    10.11 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 1KB          |   2,040.4 ns |     9.80 ns |     9.16 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 1025B        |   1,395.2 ns |     4.60 ns |     4.30 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 1025B        |   1,845.5 ns |    11.22 ns |     9.95 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 1025B        |   2,039.1 ns |     8.66 ns |     8.10 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 8KB          |  10,213.7 ns |    41.82 ns |    39.12 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 8KB          |  13,692.7 ns |   125.01 ns |   116.93 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 8KB          |  15,129.6 ns |    29.22 ns |    22.81 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 128KB        | 161,286.3 ns |   613.98 ns |   574.31 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 128KB        | 217,030.4 ns | 1,720.76 ns | 1,609.60 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 128KB        | 239,046.5 ns |   635.19 ns |   563.08 ns |      80 B |
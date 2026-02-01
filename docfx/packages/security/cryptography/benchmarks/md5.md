| Description                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · MD5 · MD5 (OS)           | 128B         |     292.1 ns |     0.81 ns |     0.76 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 128B         |     354.8 ns |     3.20 ns |     3.00 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 128B         |     395.9 ns |     1.67 ns |     1.48 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 137B         |     290.6 ns |     0.95 ns |     0.88 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 137B         |     353.9 ns |     3.59 ns |     3.36 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 137B         |     391.9 ns |     0.80 ns |     0.67 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 1KB          |   1,392.0 ns |     1.92 ns |     1.80 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 1KB          |   1,819.9 ns |    13.84 ns |    12.94 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 1KB          |   2,030.2 ns |     4.53 ns |     3.78 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 1025B        |   1,392.2 ns |     1.67 ns |     1.57 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 1025B        |   1,835.8 ns |    12.27 ns |    11.48 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 1025B        |   2,030.8 ns |     5.88 ns |     5.50 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 8KB          |  10,183.2 ns |    11.99 ns |    11.22 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 8KB          |  13,608.6 ns |   100.44 ns |    89.03 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 8KB          |  15,038.6 ns |    21.16 ns |    17.67 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 128KB        | 160,817.2 ns |   212.05 ns |   198.35 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 128KB        | 215,049.5 ns | 1,889.70 ns | 1,767.63 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 128KB        | 238,554.6 ns |   524.18 ns |   490.31 ns |      80 B |
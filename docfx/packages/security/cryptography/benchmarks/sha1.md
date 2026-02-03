| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHA-1 · SHA-1 (OS)           | 128B         |     259.1 ns |     0.78 ns |     0.73 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 128B         |     459.9 ns |     1.86 ns |     1.65 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 128B         |     485.3 ns |     3.12 ns |     2.92 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 137B         |     251.4 ns |     1.30 ns |     1.15 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 137B         |     462.2 ns |     2.37 ns |     2.10 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 137B         |     484.9 ns |     3.32 ns |     2.94 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 1KB          |   1,123.1 ns |     4.53 ns |     4.24 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 1KB          |   2,429.6 ns |     9.00 ns |     7.98 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 1KB          |   2,471.3 ns |    11.25 ns |     9.39 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 1025B        |   1,121.4 ns |     4.23 ns |     3.53 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 1025B        |   2,428.5 ns |    12.79 ns |    11.34 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 1025B        |   2,472.5 ns |     7.67 ns |     7.17 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 8KB          |   8,064.9 ns |    35.15 ns |    31.16 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 8KB          |  18,130.9 ns |    94.53 ns |    88.43 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 8KB          |  18,484.3 ns |   186.30 ns |   174.26 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 128KB        | 127,425.3 ns |   709.58 ns |   629.02 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 128KB        | 286,788.2 ns | 1,124.15 ns |   996.53 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 128KB        | 291,498.6 ns | 1,883.09 ns | 1,761.44 ns |      96 B |
| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHA-1 · SHA-1 (OS)           | 128B         |     271.8 ns |     1.11 ns |     0.93 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 128B         |     462.0 ns |     1.78 ns |     1.67 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 128B         |     487.4 ns |     1.70 ns |     1.42 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 137B         |     255.8 ns |     2.26 ns |     1.88 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 137B         |     465.0 ns |     1.88 ns |     1.66 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 137B         |     485.9 ns |     3.17 ns |     2.96 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 1KB          |   1,127.8 ns |     6.10 ns |     5.09 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 1KB          |   2,430.1 ns |    15.30 ns |    14.31 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 1KB          |   2,484.5 ns |    13.62 ns |    11.38 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 1025B        |   1,143.2 ns |     3.70 ns |     3.09 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 1025B        |   2,439.6 ns |    10.33 ns |     9.67 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 1025B        |   2,489.3 ns |    16.22 ns |    15.17 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 8KB          |   8,094.7 ns |    43.63 ns |    38.67 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 8KB          |  18,170.7 ns |    78.57 ns |    73.50 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 8KB          |  18,417.1 ns |   102.03 ns |    95.44 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 128KB        | 127,492.3 ns |   574.08 ns |   508.91 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 128KB        | 289,098.3 ns | 2,026.83 ns | 1,692.49 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 128KB        | 290,706.4 ns | 1,074.78 ns |   952.76 ns |      96 B |
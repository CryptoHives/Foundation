| Description                                | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| ComputeHash · SHA-1 · SHA-1 (OS)           | 128B         |     252.9 ns |     1.53 ns |   1.43 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 128B         |     460.2 ns |     1.58 ns |   1.48 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 128B         |     484.3 ns |     1.48 ns |   1.15 ns |      96 B |
|                                            |              |              |             |           |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 137B         |     251.4 ns |     1.41 ns |   1.32 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 137B         |     461.8 ns |     1.95 ns |   1.82 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 137B         |     481.5 ns |     2.45 ns |   2.29 ns |      96 B |
|                                            |              |              |             |           |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 1KB          |   1,125.3 ns |     4.77 ns |   4.46 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 1KB          |   2,420.5 ns |     7.91 ns |   6.17 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 1KB          |   2,483.1 ns |    17.65 ns |  16.51 ns |      96 B |
|                                            |              |              |             |           |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 1025B        |   1,129.7 ns |     6.38 ns |   5.96 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 1025B        |   2,433.1 ns |    14.49 ns |  12.84 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 1025B        |   2,476.7 ns |    10.23 ns |   9.57 ns |      96 B |
|                                            |              |              |             |           |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 8KB          |   8,069.5 ns |    26.72 ns |  24.99 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 8KB          |  18,242.2 ns |    53.47 ns |  47.40 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 8KB          |  18,334.1 ns |    85.07 ns |  75.41 ns |      96 B |
|                                            |              |              |             |           |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 128KB        | 127,334.9 ns |   577.72 ns | 540.40 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 128KB        | 286,781.3 ns |   980.22 ns | 818.53 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 128KB        | 290,884.4 ns | 1,117.67 ns | 990.79 ns |      96 B |
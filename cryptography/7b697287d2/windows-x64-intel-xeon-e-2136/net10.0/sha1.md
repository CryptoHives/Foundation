| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     481.2 ns |     0.42 ns |     0.37 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     944.5 ns |     1.45 ns |     1.35 ns |   2,745 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |   1,053.3 ns |     4.52 ns |     4.23 ns |   5,118 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     480.9 ns |     0.62 ns |     0.58 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     928.6 ns |     1.34 ns |     1.19 ns |   2,759 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |   1,102.8 ns |     1.63 ns |     1.53 ns |   5,119 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   2,150.1 ns |     1.46 ns |     1.22 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   4,821.7 ns |    11.02 ns |     9.77 ns |   2,747 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   5,685.4 ns |    12.43 ns |    11.02 ns |   5,123 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   2,153.1 ns |     1.92 ns |     1.70 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   4,812.7 ns |    11.78 ns |     9.83 ns |   2,761 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   5,687.1 ns |    12.96 ns |    11.49 ns |   5,127 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |  15,137.2 ns |    11.87 ns |    11.11 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  35,459.7 ns |    81.45 ns |    68.01 ns |   2,747 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  43,413.4 ns |    84.19 ns |    70.30 ns |   5,139 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 237,611.7 ns |   126.67 ns |   105.78 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 562,427.1 ns | 1,577.12 ns | 1,398.08 ns |   2,768 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 679,239.2 ns | 1,902.82 ns | 1,686.80 ns |   5,078 B |         - |
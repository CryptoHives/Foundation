| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     483.1 ns |     0.54 ns |     0.50 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     949.8 ns |     6.37 ns |     4.97 ns |   2,745 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |   1,106.8 ns |     9.76 ns |     9.13 ns |   5,118 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     481.1 ns |     0.44 ns |     0.41 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     931.0 ns |     4.80 ns |     3.75 ns |   2,759 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |   1,060.0 ns |     5.99 ns |     5.01 ns |   5,111 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   2,148.3 ns |     3.91 ns |     3.66 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   4,854.9 ns |    43.89 ns |    41.05 ns |   2,747 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   5,741.6 ns |    55.48 ns |    51.90 ns |   5,123 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   2,147.4 ns |     3.12 ns |     2.92 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   4,839.1 ns |    28.57 ns |    23.86 ns |   2,761 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   5,774.0 ns |    54.69 ns |    51.16 ns |   5,127 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |  15,075.0 ns |    25.05 ns |    23.44 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  35,790.5 ns |   330.61 ns |   293.08 ns |   2,747 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  44,420.2 ns |   535.07 ns |   500.51 ns |   4,977 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 237,199.2 ns |   351.82 ns |   311.88 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 568,665.9 ns | 9,214.39 ns | 8,619.14 ns |   2,768 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 683,855.1 ns | 7,620.10 ns | 6,755.02 ns |   5,078 B |         - |
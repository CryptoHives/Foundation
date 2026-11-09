| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     360.2 ns |     0.99 ns |     0.88 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     698.2 ns |     0.78 ns |     0.65 ns |   2,745 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     800.5 ns |     1.11 ns |     1.04 ns |   5,103 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     354.4 ns |     0.65 ns |     0.61 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     685.1 ns |     0.90 ns |     0.80 ns |   2,759 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     813.8 ns |     1.81 ns |     1.69 ns |   5,119 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,599.3 ns |     2.98 ns |     2.64 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   3,559.8 ns |     4.07 ns |     3.80 ns |   2,747 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   4,196.2 ns |    11.47 ns |    10.73 ns |   5,131 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,603.3 ns |     2.68 ns |     2.50 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   3,557.8 ns |     5.16 ns |     4.57 ns |   2,761 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   4,279.8 ns |    12.71 ns |    11.26 ns |   5,128 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |  11,195.7 ns |    21.24 ns |    19.87 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  26,146.2 ns |   174.76 ns |   136.44 ns |   2,747 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  33,829.8 ns |   104.50 ns |    92.63 ns |   5,139 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 175,563.4 ns |   321.77 ns |   300.99 ns |   4,450 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 414,131.9 ns |   834.39 ns |   696.75 ns |   2,768 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 504,846.3 ns | 6,150.40 ns | 5,753.09 ns |   5,078 B |         - |
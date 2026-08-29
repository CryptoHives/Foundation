| Description                               | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     268.3 ns |     0.88 ns |     0.74 ns |   4,412 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     269.3 ns |     0.64 ns |     0.50 ns |   4,280 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     380.9 ns |     0.57 ns |     0.50 ns |   6,902 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 137B         |     267.6 ns |     0.62 ns |     0.51 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     273.6 ns |     0.69 ns |     0.58 ns |   4,400 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     379.5 ns |     0.48 ns |     0.43 ns |   6,914 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,370.3 ns |     1.61 ns |     1.34 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,482.7 ns |    26.98 ns |    29.99 ns |   4,412 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,028.9 ns |     5.13 ns |     4.28 ns |   6,929 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,371.0 ns |     2.64 ns |     2.06 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,477.7 ns |     4.86 ns |     4.31 ns |   4,405 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,029.5 ns |     2.97 ns |     2.48 ns |   6,914 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  10,166.6 ns |    11.91 ns |     9.30 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  11,207.2 ns |   179.77 ns |   159.37 ns |   4,412 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  15,230.3 ns |    29.55 ns |    27.65 ns |   6,757 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 161,123.4 ns |   303.58 ns |   237.01 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 176,819.3 ns | 3,380.83 ns | 2,639.53 ns |   4,422 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 241,080.8 ns |   648.54 ns |   606.64 ns |   6,874 B |         - |
| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     434.1 ns |     1.41 ns |     1.25 ns |   5,608 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 128B         |     577.4 ns |     2.18 ns |     2.04 ns |   5,383 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     610.0 ns |     2.73 ns |     2.42 ns |   5,915 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 128B         |     834.1 ns |     1.91 ns |     1.78 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     434.3 ns |     1.42 ns |     1.33 ns |   5,610 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 137B         |     570.9 ns |     1.87 ns |     1.66 ns |   5,383 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     612.8 ns |     3.95 ns |     3.50 ns |   5,910 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 137B         |     843.8 ns |     2.15 ns |     1.90 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   2,931.9 ns |     8.33 ns |     7.38 ns |   5,592 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 1KB          |   3,694.0 ns |    12.14 ns |    11.36 ns |   5,365 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   3,967.2 ns |    10.88 ns |    10.17 ns |   8,240 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 1KB          |   4,193.7 ns |    23.29 ns |    19.45 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   2,944.3 ns |    12.70 ns |    11.88 ns |   5,594 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 1025B        |   3,800.6 ns |    10.77 ns |    10.07 ns |   5,367 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   3,971.1 ns |    12.20 ns |    11.41 ns |   8,211 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 1025B        |   4,223.8 ns |    46.60 ns |    43.59 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |  20,003.0 ns |    79.83 ns |    74.68 ns |   5,598 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 8KB          |  25,632.5 ns |   101.99 ns |    95.40 ns |   5,369 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |  27,546.2 ns |    14.98 ns |    13.28 ns |   8,242 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 8KB          |  27,905.5 ns |   173.79 ns |   162.56 ns |   1,509 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 317,078.8 ns | 1,082.95 ns | 1,012.99 ns |   5,592 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 128KB        | 416,330.1 ns | 2,083.70 ns | 1,949.10 ns |   5,365 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 439,360.0 ns |   359.71 ns |   318.88 ns |   8,210 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 128KB        | 441,045.3 ns | 4,171.65 ns | 3,902.16 ns |   1,507 B |         - |
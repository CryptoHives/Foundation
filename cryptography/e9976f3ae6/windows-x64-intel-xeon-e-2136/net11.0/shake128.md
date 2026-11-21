| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     437.5 ns |     0.74 ns |     0.65 ns |  16,312 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 128B         |     551.6 ns |     0.77 ns |     0.72 ns |   9,752 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     604.3 ns |     0.49 ns |     0.41 ns |  14,866 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 128B         |     831.0 ns |     1.71 ns |     1.60 ns |  10,579 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     437.8 ns |     0.34 ns |     0.30 ns |  16,312 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 137B         |     554.2 ns |     2.97 ns |     2.48 ns |  16,087 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     611.5 ns |     2.05 ns |     1.92 ns |  14,676 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 137B         |     835.1 ns |     0.85 ns |     0.71 ns |   4,244 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   2,939.9 ns |     5.74 ns |     5.09 ns |  16,507 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 1KB          |   3,794.2 ns |     5.90 ns |     5.23 ns |   9,733 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   3,904.5 ns |     2.50 ns |     2.09 ns |  16,575 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 1KB          |   4,221.4 ns |    36.25 ns |    33.91 ns |   4,244 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   2,933.2 ns |     1.04 ns |     0.92 ns |   9,973 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 1025B        |   3,754.4 ns |     9.06 ns |     8.03 ns |  16,068 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   3,906.3 ns |     4.06 ns |     3.80 ns |  16,765 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 1025B        |   4,196.8 ns |    12.36 ns |    10.32 ns |  10,579 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |  20,035.0 ns |   123.64 ns |   115.65 ns |  16,308 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 8KB          |  25,720.1 ns |    65.08 ns |    60.88 ns |  16,083 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |  27,146.5 ns |    17.06 ns |    15.12 ns |  16,757 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 8KB          |  27,815.5 ns |    46.69 ns |    36.45 ns |  10,769 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 316,691.4 ns |   755.66 ns |   706.84 ns |   9,982 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 128KB        | 404,301.6 ns | 1,567.15 ns | 1,389.23 ns |   9,733 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 431,054.7 ns |   277.91 ns |   259.96 ns |  16,577 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 128KB        | 440,013.5 ns | 3,098.00 ns | 2,897.87 ns |  10,769 B |         - |
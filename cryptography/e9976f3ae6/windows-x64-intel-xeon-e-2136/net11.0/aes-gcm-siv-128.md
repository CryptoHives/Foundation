| Description                                           | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       421.1 ns |     0.16 ns |     0.13 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,995.2 ns |     4.83 ns |     3.77 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |     2,757.4 ns |     7.58 ns |     6.72 ns |     310 B |    2992 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128B         |       332.8 ns |     0.50 ns |     0.42 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128B         |     1,926.6 ns |    11.52 ns |    10.77 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128B         |     2,620.0 ns |     8.50 ns |     7.95 ns |     390 B |    2544 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,304.8 ns |     4.20 ns |     3.93 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |    10,753.2 ns |    46.65 ns |    43.64 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |    12,569.2 ns |    69.16 ns |    64.69 ns |     310 B |    7416 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 1KB          |     1,213.3 ns |     2.07 ns |     1.83 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 1KB          |     9,985.4 ns |    27.77 ns |    25.97 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 1KB          |    11,499.7 ns |    19.09 ns |    15.94 ns |     390 B |    3312 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     8,300.5 ns |     6.09 ns |     5.08 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    74,495.2 ns |   306.36 ns |   286.57 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |    88,396.3 ns |   286.32 ns |   267.82 ns |     310 B |   43328 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 8KB          |     8,231.9 ns |    23.16 ns |    21.66 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 8KB          |    74,208.3 ns |   353.60 ns |   330.76 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 8KB          |    82,168.7 ns |   144.17 ns |   120.39 ns |     390 B |   10480 B |
|                                                       |              |                |             |             |           |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   128,812.4 ns |   145.01 ns |   128.55 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,170,992.5 ns | 4,362.44 ns | 3,405.91 ns |     310 B |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 1,676,909.1 ns | 4,045.66 ns | 3,158.58 ns |     310 B |  658039 B |
|                                                       |              |                |             |             |           |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-AES-NI+PClMul) | 128KB        |   128,813.8 ns |   199.95 ns |   177.25 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)        | 128KB        | 1,161,121.0 ns | 1,650.75 ns | 1,288.80 ns |     390 B |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)              | 128KB        | 1,370,425.6 ns | 1,676.51 ns | 1,399.96 ns |     390 B |  133413 B |
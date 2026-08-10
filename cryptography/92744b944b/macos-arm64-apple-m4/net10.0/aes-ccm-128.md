| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     273.1 ns |     1.38 ns |     1.07 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     955.0 ns |     0.57 ns |     0.44 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,441.3 ns |     2.64 ns |     2.20 ns |    2424 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     237.8 ns |     4.33 ns |     3.84 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     907.0 ns |     2.51 ns |     2.09 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,381.0 ns |     6.24 ns |     5.84 ns |    2464 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,562.1 ns |     3.02 ns |     2.52 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,997.1 ns |     1.73 ns |     1.61 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,842.8 ns |     2.05 ns |     1.91 ns |    2424 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,509.6 ns |     9.00 ns |     7.98 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,953.8 ns |     1.47 ns |     1.31 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,562.9 ns |    40.12 ns |    33.50 ns |    2464 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,859.9 ns |     4.50 ns |     4.21 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  46,249.3 ns |     7.77 ns |     6.89 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,068.6 ns |    18.44 ns |    17.25 ns |    2424 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,361.4 ns |    59.40 ns |    55.56 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  45,878.6 ns |   537.76 ns |   419.84 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  49,030.8 ns |   174.47 ns |   145.69 ns |    2464 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 188,074.5 ns |   317.22 ns |   296.73 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 736,377.3 ns |   117.59 ns |   109.99 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 793,130.6 ns |   451.95 ns |   422.76 ns |    2424 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 182,973.9 ns | 1,031.92 ns |   965.26 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 726,173.1 ns | 5,011.64 ns | 4,184.95 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 799,450.8 ns | 6,038.70 ns | 5,042.59 ns |    2464 B |
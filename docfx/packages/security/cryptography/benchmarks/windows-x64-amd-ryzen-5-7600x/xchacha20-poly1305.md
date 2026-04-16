| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     553.1 ns |   0.90 ns |   0.84 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     601.3 ns |   0.68 ns |   0.53 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     909.7 ns |   1.84 ns |   1.72 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,088.9 ns |   2.09 ns |   1.96 ns |         - |
|                                                   |              |              |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     496.9 ns |   1.08 ns |   1.01 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     571.8 ns |   0.93 ns |   0.87 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     868.8 ns |   0.85 ns |   0.75 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,049.0 ns |   1.69 ns |   1.50 ns |         - |
|                                                   |              |              |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,468.4 ns |   2.00 ns |   1.77 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,928.4 ns |   2.85 ns |   2.66 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,044.4 ns |   5.64 ns |   5.28 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,673.9 ns |   9.18 ns |   8.14 ns |         - |
|                                                   |              |              |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,424.9 ns |   1.89 ns |   1.77 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,888.4 ns |   1.97 ns |   1.84 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,015.7 ns |  11.00 ns |  10.29 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,632.1 ns |   6.85 ns |   5.72 ns |         - |
|                                                   |              |              |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,871.9 ns |  10.92 ns |  10.22 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,533.7 ns |  15.80 ns |  14.78 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  28,924.8 ns |  48.89 ns |  45.73 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,398.1 ns |  89.04 ns |  78.93 ns |         - |
|                                                   |              |              |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,812.9 ns |  16.73 ns |  15.65 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,487.5 ns |  18.97 ns |  17.74 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  28,991.2 ns |  52.43 ns |  49.04 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,341.5 ns |  72.12 ns |  67.46 ns |         - |
|                                                   |              |              |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 135,633.8 ns | 263.95 ns | 246.90 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,129.7 ns | 114.30 ns | 101.32 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 460,198.9 ns | 747.37 ns | 699.09 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 525,478.9 ns | 933.12 ns | 872.84 ns |         - |
|                                                   |              |              |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 135,635.0 ns | 263.60 ns | 246.57 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,255.7 ns | 179.69 ns | 168.09 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 457,220.5 ns | 872.94 ns | 816.55 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 525,335.5 ns | 904.41 ns | 845.98 ns |         - |
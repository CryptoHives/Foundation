| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     561.5 ns |   0.44 ns |   0.37 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     627.3 ns |   0.60 ns |   0.50 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     912.1 ns |   1.07 ns |   0.95 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,121.4 ns |   2.29 ns |   2.03 ns |         - |
|                                                   |              |              |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     509.2 ns |   0.77 ns |   0.69 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     583.3 ns |   1.00 ns |   0.93 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     871.9 ns |   1.67 ns |   1.48 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,078.7 ns |   1.13 ns |   0.94 ns |         - |
|                                                   |              |              |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,495.5 ns |   2.71 ns |   2.54 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,947.1 ns |   5.18 ns |   4.59 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,082.9 ns |  10.98 ns |  10.27 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,796.5 ns |  13.78 ns |  12.89 ns |         - |
|                                                   |              |              |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,451.3 ns |   2.45 ns |   1.91 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,902.6 ns |   3.39 ns |   2.64 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,039.0 ns |  19.62 ns |  17.39 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,768.0 ns |   9.61 ns |   8.52 ns |         - |
|                                                   |              |              |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,975.9 ns |  11.51 ns |  10.20 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,615.6 ns |  17.26 ns |  16.14 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  29,297.7 ns |  69.06 ns |  64.60 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  34,340.1 ns |  51.36 ns |  45.53 ns |         - |
|                                                   |              |              |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,926.9 ns |  13.06 ns |  11.57 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,549.0 ns |  25.91 ns |  22.97 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  29,033.4 ns |  39.45 ns |  32.94 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  34,162.4 ns |  33.25 ns |  31.10 ns |         - |
|                                                   |              |              |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 137,509.7 ns | 174.43 ns | 154.62 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 195,040.1 ns | 197.63 ns | 165.03 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 463,772.7 ns | 701.71 ns | 622.04 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 539,500.8 ns | 695.45 ns | 616.50 ns |         - |
|                                                   |              |              |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 137,591.1 ns | 223.36 ns | 198.00 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,991.9 ns | 286.67 ns | 254.12 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 458,852.0 ns | 776.69 ns | 688.51 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 539,116.8 ns | 702.43 ns | 657.06 ns |         - |
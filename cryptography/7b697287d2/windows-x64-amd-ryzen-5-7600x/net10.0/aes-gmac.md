| Description                                | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      51.88 ns |   0.148 ns |   0.123 ns |  13,498 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     530.63 ns |   1.517 ns |   1.267 ns |  21,284 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      57.02 ns |   0.087 ns |   0.082 ns |  13,504 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     563.48 ns |   1.175 ns |   0.981 ns |  21,869 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     143.82 ns |   0.351 ns |   0.328 ns |  13,501 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   1,455.71 ns |   2.286 ns |   2.139 ns |  21,255 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     157.72 ns |   0.305 ns |   0.285 ns |  13,507 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   1,758.77 ns |   2.452 ns |   2.293 ns |  21,566 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |     884.18 ns |   1.092 ns |   1.022 ns |  13,498 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |   8,814.37 ns |   9.081 ns |   8.495 ns |  21,029 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  13,615.11 ns |  17.640 ns |  16.501 ns |  13,498 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 139,595.62 ns | 275.380 ns | 257.591 ns |  21,212 B |    1816 B |
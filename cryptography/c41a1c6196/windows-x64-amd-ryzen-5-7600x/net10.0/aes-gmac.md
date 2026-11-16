| Description                                | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      51.76 ns |   0.070 ns |   0.062 ns |  13,498 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     528.58 ns |   1.610 ns |   1.345 ns |  21,287 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      56.94 ns |   0.084 ns |   0.066 ns |  13,504 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     549.80 ns |   1.194 ns |   0.997 ns |  21,869 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     144.03 ns |   0.297 ns |   0.248 ns |  13,501 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   1,463.65 ns |   5.248 ns |   4.382 ns |  21,255 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     157.63 ns |   0.298 ns |   0.264 ns |  13,507 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   1,483.49 ns |   6.028 ns |   5.033 ns |  21,884 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |     886.99 ns |   3.820 ns |   3.190 ns |  13,498 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |   8,825.73 ns |  12.088 ns |  11.307 ns |  21,029 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  13,604.12 ns |  22.207 ns |  18.544 ns |  13,498 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 139,555.50 ns | 461.219 ns | 431.424 ns |  21,210 B |    1816 B |
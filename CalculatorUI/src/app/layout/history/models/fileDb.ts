import { FileBase } from "./fileBase";

export class FileDb extends FileBase {
    FileId!: number;
    Extension!: string;
    Date!: Date;
}
